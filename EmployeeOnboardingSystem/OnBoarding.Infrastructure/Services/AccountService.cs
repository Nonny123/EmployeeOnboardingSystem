using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Onboarding.Domain.DTOs;
using Onboarding.Domain.Entities;
using OnBoarding.Application.Helpers;
using OnBoarding.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(UserManager<User> userManager, IConfiguration configuration, IMailService mailService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mailService = mailService;
            _roleManager = roleManager;

        }
        public async Task<Responses> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            Responses responseBody = new Responses();
            // No user matches the email
            if (string.IsNullOrEmpty(email))
            {
                responseBody.Message = "Email address not specified";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return responseBody;
            }

            // Matching user found
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["FrontendURL"]}/ResetPassword?email={email}&token={validToken}";

            //sends the mail to the user
            EmailRequest mailRequest = new EmailRequest()
            {
                ToEmail = email,
                Subject = "Onboarding Password Reset",
                Body = $"Click on this link to reset your password: {url}"
            };

            await _mailService.SendEmailAsync(mailRequest);
            responseBody.Message = $"A password reset link has been sent to {email}";
            responseBody.Status = "Success";
            responseBody.Payload = null;

            return responseBody;
        }

        public async Task<Responses> LoginAsync(UserLogin model)
        {
            Responses responseBody = new Responses();

            User user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                IList<string> assignedRoles = await _userManager.GetRolesAsync(user);

                List<Claim> authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (string role in assignedRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                // Assign response body properties for successful login
                responseBody.Message = "Logged in successfully";
                responseBody.Status = "Success";
                responseBody.Payload = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };
                return (responseBody);
            }

            // Assign response body properties for unsuccessful login
            responseBody.Message = "Login attempt was unsuccessful. Invalid email address or password.";
            responseBody.Status = "Failed";
            responseBody.Payload = null;
            return (responseBody);
        }

        public async Task<Responses> ResetPasswordAsync(ResetPassword model)
        {
            Responses responseBody = new Responses();
            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user == null)
            {
                responseBody.Message = "Validation failed. Please check your entries and try again";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return responseBody;
            }
            //***token should be extracted for the URL ***

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);
            await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);
            responseBody.Message = "Password has been reset successfully";
            responseBody.Status = "Success";
            responseBody.Payload = null;
            return responseBody;
        }
    }
}

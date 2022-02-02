using Microsoft.AspNetCore.Mvc;
using Onboarding.Domain.DTOs;
using OnBoarding.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin model)
        {
            var response = await _accountService.LoginAsync(model);
            if (response.Status == "Failed")
            {
                return Unauthorized(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(string email)
        {
            var response = await _accountService.ForgotPasswordAsync(email);
            if (response.Status == "Failed")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPassword model)
        {
            var response = await _accountService.ResetPasswordAsync(model);
            if (!ModelState.IsValid && response.Status == "Failed")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}

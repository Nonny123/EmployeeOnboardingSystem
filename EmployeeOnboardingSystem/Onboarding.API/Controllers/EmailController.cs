using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Onboarding.Domain.Entities;
using OnBoarding.Application.Helpers;
using OnBoarding.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IWebHostEnvironment _host;
        private readonly IMailService _mailService;
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;

        public EmailController(IWebHostEnvironment host, IMailService mailService, IEmployeeService employeeService, IUserService userService)
        {
            _host = host;
            _mailService = mailService;
            _employeeService = employeeService;
            _userService = userService;
        }

        [HttpPost]
        [Route("send-email")]
        public async Task<IActionResult> SendEmailAsync([FromBody] EmailRequest emailRequest)
        {
            Responses responseBody = new Responses();

            try
            {
                await _mailService.SendEmailAsync(emailRequest);

                responseBody.Message = "Email sent successfully";
                responseBody.Status = "Success";
                responseBody.Payload = null;

                return Ok(responseBody);
            }
            catch (Exception ex)
            {
                responseBody.Message = "Email not sent";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }
        }

        [HttpPost]
        [Route("send-bulk-email-to-users")]
        public async Task<IActionResult> SendBulkEmailToUsersAsync([FromBody] EmailRequest mailRequest)
        {
            Responses responseBody = new Responses();

            try
            {
                var users = await _userService.GetAllUserAsync();
                foreach (var user in users.Data)
                {
                    mailRequest.ToEmail = user.Email;
                    await _mailService.SendEmailAsync(mailRequest);
                    await Task.FromResult(0);
                }

                responseBody.Message = "Bulk Email sent successfully";
                responseBody.Status = "Success";
                responseBody.Payload = null;

                return Ok(responseBody);
            }
            catch (Exception)
            {
                responseBody.Message = "Bulk Email not sent";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }
        }
        [HttpPost]
        [Route("send-bulk-email-to-employees")]
        public async Task<IActionResult> SendBulkEmailToEmployeesAsync([FromBody] EmailRequest mailRequest)
        {
            Responses responseBody = new Responses();

            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                foreach (var employee in employees.Data)
                {
                    mailRequest.ToEmail = employee.WorkEmail;
                    await _mailService.SendEmailAsync(mailRequest);
                    await Task.FromResult(0);
                }

                responseBody.Message = "Bulk Email sent successfully";
                responseBody.Status = "Success";
                responseBody.Payload = null;

                return Ok(responseBody);
            }
            catch (Exception)
            {
                responseBody.Message = "Bulk Email not sent";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }
        }
    }
}

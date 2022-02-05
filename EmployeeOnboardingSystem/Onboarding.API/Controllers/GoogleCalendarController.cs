using Microsoft.AspNetCore.Mvc;
using Onboarding.Domain.DTOs;
using OnBoarding.Application.Helpers;
using OnBoarding.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoogleCalendarController : ControllerBase
    {
        private readonly IGoogleCalendarService _googleCalendarService;


        public GoogleCalendarController(IGoogleCalendarService googleCalendarService)
        {
            _googleCalendarService = googleCalendarService;
        }

        [HttpPost]
        [Route("invite-all-employees")]
        public IActionResult InviteAllEmployees(GoogleCalendarEventInviteDto googleCalendarEventInviteDto)
        {
            Responses responseBody = new Responses();

            try
            {
                _googleCalendarService.InviteAllEmployees(googleCalendarEventInviteDto);

                responseBody.Message = "Invites sent successfully";
                responseBody.Status = "Success";
                responseBody.Payload = null;

                return Ok(responseBody);
            }
            catch (Exception)
            {
                responseBody.Message = "Invites not sent";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }


        }

        [HttpPost]
        [Route("invite-employee")]
        public IActionResult InviteEmployee(string employeeId, GoogleCalendarEventInviteDto googleCalendarEventInviteDto)
        {
            Responses responseBody = new Responses();

            try
            {
                _googleCalendarService.InviteEmployee(employeeId, googleCalendarEventInviteDto);

                responseBody.Message = "Invite sent successfully";
                responseBody.Status = "Success";
                responseBody.Payload = null;

                return Ok(responseBody);
            }
            catch (Exception)
            {
                responseBody.Message = "Invite not sent";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }
        }

        [HttpPost]
        [Route("invite-new-employees")]
        public IActionResult InviteNewEmployees(GoogleCalendarEventInviteDto googleCalendarEventInviteDto)
        {
            Responses responseBody = new Responses();

            try
            {
                _googleCalendarService.InviteNewEmployees(googleCalendarEventInviteDto);

                responseBody.Message = "Invites sent successfully";
                responseBody.Status = "Success";
                responseBody.Payload = null;

                return Ok(responseBody);
            }
            catch (Exception)
            {
                responseBody.Message = "Invites not sent";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }


        }
    }
}

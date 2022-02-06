using Microsoft.AspNetCore.Mvc;
using OnBoarding.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlackController : ControllerBase
    {
        private readonly ISlackService _slackService;

        public SlackController(ISlackService slackService)
        {
            _slackService = slackService;
        }

        [HttpPost("new-message")]
        public async Task<IActionResult> SendMessageToAChanneWithSMB(string channel, string text)
        {
            var result = await _slackService.SendMessageToChannelWithSMB(channel, text);
            return StatusCode(result.StatusCode, result);
        }

    }
}

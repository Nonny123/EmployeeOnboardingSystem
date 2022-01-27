using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OnBoarding.Application.Helpers;
using OnBoarding.Infrastructure.Interfaces;
using SlackBotMessages;
using Message = SlackBotMessages.Models.Message;

namespace OnBoarding.Infrastructure.Services
{
    public class SlackService : ISlackService
    {
        private readonly IConfiguration _configuration;
        private const string SlackURL = "https://slack.com/api/";
        private const string Username = "chinonso.okafor";
        private static string token;
        private string slackChannel = "onboarding-app";

        public SlackService(IConfiguration configuration)
        {
            _configuration = configuration;
            token = _configuration["SlackToken"];
        }

        public async Task<Response<string>> SendMessageToChannelWithSMB(string channel, string text)
        {
            var client = new SbmClient("https://hooks.slack.com/services/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");
            Message msg = new Message()
            {
                Channel = channel,
                Text = text,
                Username = "",
                IconEmoji = ":smile:"
            };

            var send = await client.SendAsync(msg);
            if (send.Length > 0)
                return Response<string>.Success("success", $"{text} sent to channel: {channel}");

            return Response<string>.Fail("failed: something went wrong");

        }

    }
}

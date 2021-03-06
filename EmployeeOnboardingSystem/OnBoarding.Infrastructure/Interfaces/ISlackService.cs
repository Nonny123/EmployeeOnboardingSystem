using OnBoarding.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Interfaces
{
    public interface ISlackService
    {
        Task<Response<string>> SendMessageToChannelWithSMB(string channel, string text);
    }
}

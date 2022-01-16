using Onboarding.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Interfaces
{
    public interface IMailService
    {
        public Task SendEmailAsync(EmailRequest emailRequest);
    }
}

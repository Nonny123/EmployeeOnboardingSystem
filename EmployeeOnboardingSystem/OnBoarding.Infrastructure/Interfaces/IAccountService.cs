using Onboarding.Domain.DTOs;
using OnBoarding.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Interfaces
{
    public interface IAccountService
    {
        Task<Responses> ForgotPasswordAsync(string email);
        Task<Responses> ResetPasswordAsync(ResetPassword model);
        Task<Responses> LoginAsync(UserLogin model);
    }
}

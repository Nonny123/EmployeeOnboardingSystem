using Microsoft.Extensions.DependencyInjection;
using OnBoarding.Infrastructure.Interfaces;
using OnBoarding.Infrastructure.Repositories;
using OnBoarding.Infrastructure.Services;
using OnBoarding.Infrastructure.Services.EmailServices;


namespace Onboarding.API.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {

            // Add Repository Injections Here
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Add Model Services Injection Here
            services.AddScoped<IGoogleCalendarService, GoogleCalendarService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IUserService, UserService>();

            //Add Authentication injection
            services.AddScoped<IAccountService, AccountService>();

            // Add Mail service
            services.AddTransient<IMailService, MailService>();

            services.AddScoped<ISlackService, SlackService>();
        }

    }
}

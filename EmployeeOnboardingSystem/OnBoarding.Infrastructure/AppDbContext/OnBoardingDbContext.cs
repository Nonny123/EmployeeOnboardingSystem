using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.Entities;

namespace OnBoarding.Infrastructure.AppDbContext
{
    public class OnBoardingDbContext : IdentityDbContext<User>
    {
        public OnBoardingDbContext(DbContextOptions<OnBoardingDbContext> options) : base(options)
        {

        }

        public DbSet<User> AppUsers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

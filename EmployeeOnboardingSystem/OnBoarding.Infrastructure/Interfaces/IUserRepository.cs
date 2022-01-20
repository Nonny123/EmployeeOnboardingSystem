using Onboarding.Domain.Entities;
using OnBoarding.Infrastructure.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task SaveAsync();
        Task<IEnumerable<User>> SearchUserAsync(string searchTerm);
        string UpdateUserAvatar(User user);
        Task<User> GetUserByEmail(string email);
    }
   
}

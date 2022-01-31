using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.DTOs;
using Onboarding.Domain.Entities;
using OnBoarding.Infrastructure.AppDbContext;
using OnBoarding.Infrastructure.Interfaces;
using OnBoarding.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly OnBoardingDbContext _context;
        public UserRepository(OnBoardingDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddAsync(UserRegistrationDto userRegistration) //, ApplicationUser userInfo)
        {
            User userData = new User()
            {
                FirstName = userRegistration.FirstName,
                MiddleName = userRegistration.MiddleName,
                LastName = userRegistration.LastName,
                Gender = userRegistration.Gender,
                PhoneNumber = userRegistration.PhoneNumber,
                PhoneNumber2 = userRegistration.PhoneNumber2,
                ResidentialAddress = userRegistration.ResidentialAddress,
                CityOfResidence = userRegistration.CityOfResidence,
                StateofResidence = userRegistration.StateofResidence,
                StateofOrigin = userRegistration.StateofOrigin,
                CountryOfOrigin = userRegistration.CountryOfOrigin,
                Email = userRegistration.Email,
                //DateOfBirth = userRegistration.DateOfBirth,
                //Avatar = userRegistration.Avatar,
                DateRegistered = DateTime.Now,
                IsActive = true,
                //  AppUser = userInfo


            };
            await _context.Users.AddAsync(userData);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> SearchUserAsync(string searchTerm)
        {
            var user = await _context.Users.Where(u => u.LastName == searchTerm
                                                   || u.FirstName == searchTerm
                                                   || u.MiddleName == searchTerm
                                                   || u.Email == searchTerm
                                                   || u.PhoneNumber == searchTerm
                                                   || u.PhoneNumber2 == searchTerm
                                                   || u.StateofResidence == searchTerm
                                                   || u.StateofOrigin == searchTerm
                                                   || u.CityOfResidence == searchTerm
                                                   || u.CountryOfOrigin == searchTerm).ToListAsync();

            return user;
        }

        public string UpdateUserAvatar(User user)
        {
            _context.Users.Update(user);
            return "Success";
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
        public string UpdateEmployeeAvatar(User userUpdate)
        {
            _context.Users.Update(userUpdate);
            return "success";
        }

    }
}

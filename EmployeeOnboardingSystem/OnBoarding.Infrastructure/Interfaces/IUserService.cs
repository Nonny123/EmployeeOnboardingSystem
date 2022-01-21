using Onboarding.Domain.DTOs;
using Onboarding.Domain.Entities;
using OnBoarding.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<Response<string>> AddUserAsync(UserRegistrationDto user);
        Task<Response<string>> DeleteUserAsync(string userId);
        Task<Response<IEnumerable<UserResponseDto>>> GetAllUserAsync();
        Task<Response<UserResponseDto>> GetUserByIdAsync(string userId);
        Task<Response<IEnumerable<UserResponseDto>>> SearchUserAsync(string searchTerm);
        Task<Response<User>> UpdateUserAvatarAsync(string userId, string avatar);
        Task<Response<User>> UpdateUserAsync(string userId, UserUpdateProfileDto userUpdateProfileDto);

    }
}

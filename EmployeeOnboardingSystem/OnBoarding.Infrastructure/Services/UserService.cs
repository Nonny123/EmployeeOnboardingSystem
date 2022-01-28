using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.DTOs;
using Onboarding.Domain.Entities;
using OnBoarding.Application.Helpers;
using OnBoarding.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IMapper mapper, IUserRepository userRepository, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<Response<string>> AddUserAsync(UserRegistrationDto user)
        {
            var newUser = _mapper.Map<User>(user);
            newUser.UserName = user.Email;
            newUser.DateRegistered = DateTime.Now;
            newUser.LastModified = DateTime.Now;
            newUser.IsActive = true;
            newUser.Avatar = "https://www.pngfind.com/pngs/m/676-6764065_default-profile-picture-transparent-hd-png-download.png";

            string errors = "";

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
                return Response<string>.Success("Success", $"{user.FirstName} {user.LastName} added successfully");

            foreach (var err in result.Errors)
                errors += err + "\n";

            return Response<string>.Fail(errors);
        }
        public async Task<Response<string>> DeleteUserAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return Response<string>.Fail("User not found");
            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveAsync();
            return Response<string>.Success("Success", $"{user} with id {userId} successfully deleted", 204);
        }

        public async Task<Response<IEnumerable<UserResponseDto>>> GetAllUserAsync()
        {
            var users = _userManager.Users.ToList();
            //var users = await _userRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<UserResponseDto>>(users);
            return Response<IEnumerable<UserResponseDto>>.Success("Success", response);
        }

        public async Task<Response<UserResponseDto>> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return Response<UserResponseDto>.Fail("User not Found");
            var response = _mapper.Map<UserResponseDto>(user);
            return Response<UserResponseDto>.Success("Success", response);
        }

        public async Task<Response<IEnumerable<UserResponseDto>>> SearchUserAsync(string searchTerm)
        {
            if (searchTerm == null)
                return Response<IEnumerable<UserResponseDto>>.Fail("Search can not be empty");

            var user = await _userManager.Users.Where(u => u.LastName.Contains(searchTerm)
                                                   || u.FirstName.Contains(searchTerm)
                                                   || u.MiddleName.Contains(searchTerm)
                                                   || u.Email.Contains(searchTerm)
                                                   || u.PhoneNumber.Contains(searchTerm)
                                                   || u.PhoneNumber2.Contains(searchTerm)
                                                   || u.StateofResidence.Contains(searchTerm)
                                                   || u.StateofOrigin.Contains(searchTerm)
                                                   || u.CityOfResidence.Contains(searchTerm)
                                                   || u.CountryOfOrigin.Contains(searchTerm)).ToListAsync();

            var response = _mapper.Map<IEnumerable<UserResponseDto>>(user);
            return Response<IEnumerable<UserResponseDto>>.Success("Success", response);
        }

        public async Task<Response<User>> UpdateUserAvatarAsync(string userId, string avatar)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return Response<User>.Fail("User not found");
            user.Avatar = avatar;
            user.LastModified = DateTime.Now;
            _userRepository.UpdateUserAvatar(user);
            await _userRepository.SaveAsync();
            var response = _mapper.Map<User>(user);
            return Response<User>.Success("Success", response);
        }

        public async Task<Response<User>> UpdateUserAsync(string userId, UserUpdateProfileDto userUpdateProfileDto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return Response<User>.Fail("User not found");
            if (userUpdateProfileDto.DateOfBirth != null)
            {
                user.DateOfBirth = userUpdateProfileDto.DateOfBirth;
            }
            await _userRepository.UpdateAsync(user, user.Id);
            user.LastModified = DateTime.Now;
            await _userRepository.SaveAsync();
            var response = _mapper.Map<User>(user);

            return Response<User>.Success("success", response);
        }

        //public async Task<Response<IEnumerable<User>>> UpdateUserAsync(string userId, UserUpdateProfileDto userUpdateProfileDto)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);

        //    if (user == null)
        //        return Response<User>.Fail("User not Found");
        //    var response = _mapper.Map<User>(userUpdateProfileDto);

        //    foreach (var item in user)
        //    {
        //        await _userManager.UpdateAsync(userUpdateProfileDto);
        //    }
        //    await _userRepository.UpdateAsync(user, user.Id);
        //    user.LastModified = DateTime.Now;
        //    await _userRepository.SaveAsync();

        //    return Response<User>.Success("success", "User Updated successfully");
        //}


    }
}

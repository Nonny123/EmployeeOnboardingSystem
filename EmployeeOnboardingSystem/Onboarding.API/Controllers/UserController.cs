using Microsoft.AspNetCore.Mvc;
using Onboarding.Domain.DTOs;
using OnBoarding.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Onboarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUserAsync();
            return StatusCode(users.StatusCode, users);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return StatusCode(user.StatusCode, user);
        }

        [HttpPost]
        [Route("register_user")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto model)
        {
            var result = await _userService.AddUserAsync(model);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        [Route("update-user-avatar")]
        public async Task<IActionResult> UpdateUserProfile(string userId, string avarter)
        {
            var result = await _userService.UpdateUserAvatarAsync(userId, avarter);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [Route("search/{searchTerm}")]
        public async Task<IActionResult> SearchUserAsync(string searchTerm)
        {
            var result = await _userService.SearchUserAsync(searchTerm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(string id, UserUpdateProfileDto userUpdateProfileDto)
        {
            var result = await _userService.UpdateUserAsync(id, userUpdateProfileDto);
            return StatusCode(result.StatusCode, result);
        }

    }
}

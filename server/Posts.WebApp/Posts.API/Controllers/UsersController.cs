using Microsoft.AspNetCore.Mvc;
using Posts.Bll.Interfaces;
using Posts.Common.Dtos;

namespace Posts.API.Controllers
{
    [Route("api/users")]
    public class UsersController : AppBaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetUserAsync(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }

        [HttpPost]
        public async Task<UserDto> CreateUserAsync([FromBody] CreateUserDto userDto)
        {
            return await _userService.CreateUserAsync(userDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteUserAsync(int id)
        {
            await _userService.DeleteUserAsync(id);
        }
    }
}

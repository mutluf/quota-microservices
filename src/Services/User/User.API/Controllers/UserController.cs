using Microsoft.AspNetCore.Mvc;
using User.API.Dtos;
using User.API.Services;

namespace User.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RegisterDto userData)
        {
            
            bool result = await _userService.RegisterUserAsync(userData);
            return Ok(result);
        }
    }
}

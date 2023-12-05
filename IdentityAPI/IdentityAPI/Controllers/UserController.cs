using AutoMapper;
using IdentityAPI.Data.Dtos;
using IdentityAPI.Model;
using IdentityAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(CreateUserDto createUserDto)
        {
            await _service.Create(createUserDto);

            return Ok("User created!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var token = await _service.Login(loginUserDto);

            return Ok(token);
        }
    }
}

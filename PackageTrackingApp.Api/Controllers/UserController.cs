using Microsoft.AspNetCore.Mvc;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.Commands;
using PackageTrackingApp.Infrastructure.DTOs;
using PackageTrackingApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackageTrackingApp.Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterAsync(RegisterUser command)
        {
            await _userService.RegisterAsync(command.Email, command.Login,
                command.Password, command.ConfirmPassword);

            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> Get([FromRoute]Guid userId)
        {
            var user = await _userService.GetUserAsync(userId);

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var users = await _userService.GetUsersAsync();

            return Ok(users);
        }
    }
}

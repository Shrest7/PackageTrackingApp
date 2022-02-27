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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;

        public UserController(IUserService userService, ICommandDispatcher commandDispatcher)
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterAsync(RegisterUser command)
        {
            var guid = await _commandDispatcher.DispatchAsync(command);

            return Created($"user/{guid}", null);
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

        [HttpDelete("{guid}")]
        public async Task<ActionResult> Delete([FromRoute]Guid guid)
        {
            await _userService.DeleteUserAsync(guid);

            return NoContent();
        }

    }
}

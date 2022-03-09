using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PackageTrackingApp.Infrastructure.Commands;
using PackageTrackingApp.Infrastructure.DTOs;
using PackageTrackingApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [ProducesResponseType(201)]
        public async Task<ActionResult> RegisterAsync(RegisterUser command)
        {
            var guid = await _commandDispatcher.DispatchAsync(command);

            return Created($"user/{guid}", null);
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync(LoginUser loginUser)
        {
            var token = await _userService.LoginAsync(loginUser.Login, loginUser.Password);

            return Ok(token);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<UserDto>> Get([FromRoute] Guid userId)
        {
            var user = await _userService.GetAsync(userId);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var users = await _userService.GetAllAsync();

            if (users is null || !users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpDelete("{guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete([FromRoute]Guid guid)
        {
            await _userService.DeleteAsync(guid);

            return NoContent();
        }

        [HttpPatch("{guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Update([FromRoute] Guid guid,
            [FromBody] JsonPatchDocument<UpdateUser> patchDoc)
        {
            await _userService.UpdateAsync(guid, patchDoc);

            return NoContent();
        }
    }
}

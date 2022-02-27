using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.Services;
using PackageTrackingApp.Infrastructure.DTOs;
using PackageTrackingApp.Infrastructure.Commands;

namespace PackageTrackingApp.Api.Controllers
{
    [ApiController]
    [Route("package")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _service;
        private readonly ICommandDispatcher _commandDispatcher;

        public PackageController(IPackageService service, ICommandDispatcher commandDispatcher)
        {
            _service = service;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Package>> Post(CreatePackage package)
        {
            var guid = await _commandDispatcher.DispatchAsync(package);

            return Created($"package/{guid}", null);
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PackageDto>> Get([FromRoute] Guid guid)
        {
            var package = await _service.GetAsync(guid);

            if (package is null)
            {
                return NotFound();
            }

            return Ok(package);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpDelete("{guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete([FromRoute] Guid guid)
        {
            await _service.RemoveAsync(guid);

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Update([FromBody] Package package) //TODO
        {
            await _service.UpdateAsync(package);

            return NoContent();
        }
    }
}

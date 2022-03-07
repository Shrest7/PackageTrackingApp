using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.Services;
using PackageTrackingApp.Infrastructure.DTOs;
using PackageTrackingApp.Infrastructure.Commands;
using Microsoft.AspNetCore.JsonPatch;

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
        public async Task<ActionResult<Package>> Post([FromBody] CreatePackage package)
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
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<PackageDto>>> Get()
        {
            var packages = await _service.GetAllAsync();

            if (packages is null || !packages.Any())
            {
                return NotFound();
            }

            return Ok(packages);
        }

        [HttpDelete("{guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete([FromRoute] Guid guid)
        {
            await _service.RemoveAsync(guid);

            return NoContent();
        }

        [HttpPut("{guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Put([FromRoute] Guid guid,
            [FromBody] UpdatePackage package)
        {
            await _service.UpdateAsync(guid, package);

            return NoContent();
        }

        [HttpPatch("{guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Patch([FromRoute] Guid guid,
            [FromBody] JsonPatchDocument<PatchPackage> patchDoc)
        {
            if(patchDoc is null)
            {
                return BadRequest("PatchDoc is null.");
            }

            await _service.UpdateAsync(guid, patchDoc);

            return Ok();
        }
    }
}

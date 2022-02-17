using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.Services;
using PackageTrackingApp.Infrastructure.DTOs;

namespace PackageTrackingApp.Api.Controllers
{
    [Route("{controller}")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _service;

        public PackageController(IPackageService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Package>> Post(CreatePackageDto package)
        {
            Guid packageGuid = await _service.AddAsync(package);

            return Created($"package/{packageGuid}", new object());
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult> Get([FromRoute] Guid guid)
        {
            var package = await _service.GetAsync(guid);

            if(package is null)
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
        public async Task<ActionResult> Delete([FromRoute] Guid guid)
        {
            await _service.RemoveAsync(guid);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Package package) //TODO
        {
            await _service.UpdateAsync(package);

            return NoContent();
        }
    }
}

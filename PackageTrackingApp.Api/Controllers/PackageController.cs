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
            return Ok(_service.Add(package));
        }

        [HttpGet("{guid}")]
        public async Task<PackageDto> Get([FromRoute] Guid guid)
        {
            return await _service.Get(guid);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid guid)
        {
            await _service.Remove(guid);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            _service.RemoveAll();

            return NoContent();
        }

        [HttpPut]
        public async Task Update([FromRoute] Guid guid, [FromBody] Package package)
        {
            await _service.Update(guid, package);
        }
    }
}

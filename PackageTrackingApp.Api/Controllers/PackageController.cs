using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PackageTrackingApp.Core.Repositories;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.Services;
using PackageTrackingApp.Infrastructure.DTOs;

namespace PackageTrackingApp.Api.Controllers
{
    [Route("{controller}")]
    public class PackageController : Controller
    {
        private readonly IPackageService _service;

        public PackageController(IPackageService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        public PackageDto Get([FromRoute]string name)
        {
            return _service.Get(name);
        }

        [HttpGet("test/{guid}")]
        public PackageDto Get([FromRoute]Guid guid)
        {
            return _service.Get(guid);
        }

        [HttpGet]
        public List<PackageDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpDelete("guid")]
        public void Delete([FromRoute] Guid guid)
        {
            _service.Remove(guid);
        }
    }
}

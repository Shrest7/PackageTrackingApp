using Microsoft.AspNetCore.Mvc;
using PackageTrackingApp.Core.Repositories;
using PackageTrackingApp.Infrastructure.Commands;
using PackageTrackingApp.Infrastructure.DTOs;
using PackageTrackingApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackageTrackingApp.Api.Controllers
{
    [ApiController]
    [Route("courier")]
    public class CourierController : ControllerBase
    {
        private readonly ICourierService _courierService;
        private ICommandDispatcher _commandDispatcher;

        public CourierController(ICourierService courierService,
            ICommandDispatcher commandDispatcher)
        {
            _courierService = courierService;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{courierId}")]
        public async Task<ActionResult<CourierDto>> Get([FromRoute] Guid courierId)
        {
            var courier = await _courierService.GetCourierAsync(courierId);

            return Ok(courier);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourierDto>>> Get()
        {
            var courier = await _courierService.GetAllCouriersAsync();

            return Ok(courier);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateCourier command)
        {
            var guid = await _commandDispatcher.DispatchAsync(command);

            return Created($"courier/{guid}", null);
        }
    }
}

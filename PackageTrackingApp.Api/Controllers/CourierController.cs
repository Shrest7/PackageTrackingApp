using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CourierDto>> Get([FromRoute] Guid courierId)
        {
            var courier = await _courierService.GetCourierAsync(courierId);

            if (courier is null)
            {
                return NotFound();
            }

            return Ok(courier);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<CourierDto>>> Get()
        {
            var courier = await _courierService.GetAllCouriersAsync();

            return Ok(courier);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> Post(CreateCourier command)
        {
            var guid = await _commandDispatcher.DispatchAsync(command);

            return Created($"courier/{guid}", null);
        }

        [HttpDelete("{guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete([FromRoute] Guid guid)
        {
            await _courierService.DeleteCourierAsync(guid);

            return NoContent();
        }

        [HttpPut("{guid}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Put([FromRoute] Guid guid,
            UpdateCourier updateCourier)
        {
            await _courierService.UpdateCourierAsync(guid, updateCourier);

            return Ok();
        }
    }
}

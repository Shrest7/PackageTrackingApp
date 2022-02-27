using PackageTrackingApp.Infrastructure.Commands;
using PackageTrackingApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Handlers
{
    public class CreateCourierHandler : ICommandHandler<CreateCourier>
    {
        private readonly ICourierService _courierService;

        public CreateCourierHandler(ICourierService courierService)
        {
            _courierService = courierService;
        }

        public async Task<Guid> HandleAsync(CreateCourier command)
        {
            return await _courierService.AddCourierAsync(command);
        }
    }
}

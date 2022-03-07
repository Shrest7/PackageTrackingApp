using PackageTrackingApp.Infrastructure.Commands;
using PackageTrackingApp.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Services
{
    public interface ICourierService
    {
        Task<CourierDto> GetCourierAsync(Guid guid);
        Task<IEnumerable<CourierDto>> GetAllCouriersAsync();
        Task<Guid> AddCourierAsync(CreateCourier command);
        Task DeleteCourierAsync(Guid guid);
        Task UpdateCourierAsync(Guid guid, UpdateCourier updateCourier);
    }
}

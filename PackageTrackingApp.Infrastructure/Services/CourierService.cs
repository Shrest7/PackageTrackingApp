using AutoMapper;
using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Core.Repositories;
using PackageTrackingApp.Infrastructure.Commands;
using PackageTrackingApp.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Services
{
    public class CourierService : ICourierService
    {
        private readonly ICourierRepository _courierRepository;
        private readonly IMapper _mapper;

        public CourierService(ICourierRepository courierRepository,
            IMapper mapper)
        {
            _courierRepository = courierRepository;
            _mapper = mapper;
        }
        public async Task<Guid> AddCourierAsync(CreateCourier command)
        {
            var courier = _mapper.Map<Courier>(command);
            await _courierRepository.AddCourier(courier);
            return courier.Guid;
        }

        public async Task DeleteCourierAsync(Guid guid)
        {
            var courierToDelete = await _courierRepository.GetCourier(guid);

            if(courierToDelete is null)
            {
                Console.WriteLine($"Courier with id {guid} does not exist.");
            }

            await _courierRepository.DeleteCourier(courierToDelete);
        }

        public async Task<IEnumerable<CourierDto>> GetAllCouriersAsync()
            => _mapper.Map<IEnumerable<CourierDto>>(await _courierRepository.GetAllCouriers());

        public async Task<CourierDto> GetCourierAsync(Guid guid)
            => _mapper.Map<CourierDto>(await _courierRepository.GetCourier(guid));
    }
}

using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Repositories
{
    public class CourierRepository : ICourierRepository
    {
        private readonly PackageTrackingContext _dbContext;

        public CourierRepository(PackageTrackingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCourier(Courier courier)
        {
            await _dbContext.Couriers.AddAsync(courier);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCourier(Courier courier)
        {
            _dbContext.Couriers.Remove(courier);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Courier>> GetAllCouriers()
            => await Task.FromResult(_dbContext.Couriers);

        public async Task<Courier> GetCourier(Guid guid)
            => await Task.FromResult(_dbContext.Couriers.SingleOrDefault(x => x.Guid == guid));

    }
}

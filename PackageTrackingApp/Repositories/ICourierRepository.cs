using PackageTrackingApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Repositories
{
    public interface ICourierRepository
    {
        Task<Courier> GetCourier(Guid guid);
        Task<IEnumerable<Courier>> GetAllCouriers();
        Task AddCourier(Courier courier);
        Task DeleteCourier(Guid guid);
        Task UpdateCourier(Courier courier);
    }
}

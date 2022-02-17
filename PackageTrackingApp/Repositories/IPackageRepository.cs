using PackageTrackingApp.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Repositories
{
    public interface IPackageRepository
    {
        Task<Package> GetAsync(Guid guid);
        Task<List<Package>> GetAllAsync();
        Task AddAsync(Package package);
        Task RemoveAsync(Guid guid);
        Task UpdateAsync(Package package);
    }
}

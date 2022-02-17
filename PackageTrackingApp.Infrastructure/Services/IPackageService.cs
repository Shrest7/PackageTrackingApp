using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Services
{
    public interface IPackageService
    {
        Task<PackageDto> GetAsync(Guid guid);
        Task<List<PackageDto>> GetAllAsync();
        Task<Guid> AddAsync(CreatePackageDto package);
        Task RemoveAsync(Guid guid);
        Task UpdateAsync(Package package);
    }
}

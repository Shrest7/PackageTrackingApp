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
        Task<PackageDto> Get(Guid guid);
        Task<PackageDto> Get(string name);
        Task<List<PackageDto>> GetAll();
        Task Add(CreatePackageDto package);
        Task Remove(Guid guid);
        void RemoveAll();
        Task Update(Guid guid, Package package);
    }
}

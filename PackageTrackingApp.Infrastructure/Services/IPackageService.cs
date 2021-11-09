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
        PackageDto Get(Guid guid);
        PackageDto Get(string name);
        List<PackageDto> GetAll();
        void Add(Package package);
        void Remove(Guid guid);
        void Update(Guid guid);
    }
}

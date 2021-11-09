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
        void Add(Package package);
        void Remove(Guid guid);
        Package Get(Guid guid);
        Package Get(String name);
        ISet<Package> GetAll();
        void Update(Guid guid);
    }
}

using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Repositories
{
    public class InMemoryPackageRepository : IPackageRepository
    {
        public ISet<Package> packages = new HashSet<Package>
        {
            new Package(new Customer("Adam", "Wozniak"), new Seller("xddddd@gmail.com", "505222333"), "Nike Shoes", 11, 22, 33, 15),
            new Package(new Customer("Bartek", "Siwak"), new Seller("bddddb@onet.pl", "123123123"), "Adidas T-Shirt", 5, 10, 15, 5)
        };

        public void Add(Package package)
            => packages.Add(package);

        public Package Get(Guid guid)
            => packages.SingleOrDefault(p => p.Guid == guid);

        public Package Get(string name)
            => packages.SingleOrDefault(p => p.Name == name);

        public ISet<Package> GetAll()
            => packages;

        public void Remove(Guid guid)
        {
            var package = packages.SingleOrDefault(p => p.Guid == guid);

            packages.Remove(package);
        }

        public void Update(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}

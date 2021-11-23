using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Seeders
{
    public class PackageSeeder
    {
        private readonly PackageTrackingContext _dbContext;

        public PackageSeeder(PackageTrackingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect() && !_dbContext.Packages.Any())
            {
                ISet<Package> packages = new HashSet<Package>
                {
                    new Package(new Customer("Mike", "Wazowski"), new Seller("joe44@gmail.com", "509202301"),
                        "Nike Shoes", 1, 15, 20, 10),
                    new Package(new Customer("John", "Williams"), new Seller("bob123@gmail.com", "512956021"),
                        "Fila Disruptor", 1, 20, 20, 15),
                    new Package(new Customer("Emma", "Lol"), new Seller("bill213@gmail.com", "782321694"),
                        "Samsung TV", 7, 75, 90, 10)
                };
                _dbContext.AddRange(packages);
                _dbContext.SaveChanges();
            }
        }
    }
}

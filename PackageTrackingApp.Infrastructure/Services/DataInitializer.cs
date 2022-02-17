using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IPackageService _packageService;

        public DataInitializer(IPackageService packageService)
        {
            _packageService = packageService;
        }

        public Task InitializeDataAsync()
        {
            var packages = GetDefaultPackages();
            foreach (var package in packages)
            {
                _packageService.AddAsync(package);
            }

            return Task.CompletedTask;
        }

        private ISet<CreatePackageDto> GetDefaultPackages()
        {
            ISet<CreatePackageDto> packages = new HashSet<CreatePackageDto>
            {
                //new CreatePackageDto(new Customer("Mike", "Wazowski"), new Seller("joe44@gmail.com", "509202301"),
                //    "Nike Shoes", 1, 15, 20, 10),
                //new CreatePackageDto(new Customer("John", "Williams"), new Seller("bob123@gmail.com", "512956021"),
                //    "Fila Disruptor", 1, 20, 20, 15),
                //new CreatePackageDto(new Customer("Emma", "Lol"), new Seller("bill213@gmail.com", "782321694"),
                //    "Samsung TV", 7, 75, 90, 10)
            };

            return packages;
        }
    }
}

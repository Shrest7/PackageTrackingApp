using Microsoft.EntityFrameworkCore;
using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.Commands;
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
        private readonly IUserService _userService;
        private readonly ICourierService _courierService;
        private readonly PackageTrackingContext _dbContext;
        private const int _numberOfUsersToInitialize = 4;
        private const int _numberOfCouriersToInitialize = 2;

        public DataInitializer(IPackageService packageService, IUserService userService,
            ICourierService courierService, PackageTrackingContext dbContext)
        {
            _packageService = packageService;
            _userService = userService;
            _courierService = courierService;
            _dbContext = dbContext;
        }

        public async Task InitializeData()
        {
            var users = await _userService.GetAllAsync();
            Guid[] defaultUsersGuids = new Guid[_numberOfUsersToInitialize];
            Guid[] defaultCourierGuids = new Guid[_numberOfCouriersToInitialize];

            if (!users.Any())
            {
                _dbContext.Users.FromSqlRaw("CREATE UNIQUE INDEX IDX_Login ON Users (Login)");
                defaultUsersGuids = await InitializeUsers();
                defaultCourierGuids = await InitializeCouriers();

                await InitializePackages(defaultUsersGuids, defaultCourierGuids);
            }
        }

        private async Task<Guid[]> InitializeCouriers()
        {
            Guid[] courierGuids = new Guid[_numberOfCouriersToInitialize];
            Random rng = new Random();

            for(int i = 0; i<_numberOfCouriersToInitialize; i++)
            {
                var command = new CreateCourier()
                {
                    DateOfBirth = DateTime.UtcNow - 
                                    DateTime.Parse($"199{rng.Next(0, 10)}-10-23").TimeOfDay,
                    FirstName = $"test{i}",
                    LastName = $"test{i}",
                };

                courierGuids[i] = await _courierService.AddCourierAsync(command);
            }

            return courierGuids;
        }


        private async Task<Guid[]> InitializeUsers()
        {
            Guid[] userGuids = new Guid[_numberOfUsersToInitialize];

            for (int i = 0; i < _numberOfUsersToInitialize; i++)
            {
                userGuids[i] = await _userService.RegisterAsync($"user{i}@gmail.com", $"user{i}",
                    $"1233{i}A", $"1233{i}A", DateTime.Parse($"199{i}-01-1{i}"));
            }

            return userGuids;
        }

        private async Task InitializePackages(Guid[] usersGuids, Guid[] couriersGuids)
        {
            CreatePackage[] packages = new CreatePackage[_numberOfUsersToInitialize]
            {
                new CreatePackage(usersGuids[0], usersGuids[1], couriersGuids[0],
                    "Nike shoes", 1.5f, 10, 15, 20),
                new CreatePackage(usersGuids[2], usersGuids[3], couriersGuids[0],
                    "Fila shoes", 2, 15, 15, 15),
                new CreatePackage(usersGuids[1], usersGuids[3], couriersGuids[1],
                    "iPhone 13", 1, 100, 55, 75),
                new CreatePackage(usersGuids[0], usersGuids[2], couriersGuids[1],
                    "Gucci Ace", 1.5f, 15, 25, 8)
            };

            for (int i = 0; i < _numberOfUsersToInitialize; i++)
            {
                await _packageService.AddAsync(packages[i]);
            }
        }
    }
}

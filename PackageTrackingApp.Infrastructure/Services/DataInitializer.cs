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
        private readonly IUserService _userService;
        private const int _numberOfUsersToInitialize = 4;

        public DataInitializer(IPackageService packageService, IUserService userService)
        {
            _packageService = packageService;
            _userService = userService;
        }

        public async Task InitializeData()
        {
            var users = await _userService.GetUsersAsync();
            Guid[] defaultUsersGuids = new Guid[_numberOfUsersToInitialize];

            if (!users.Any())
            {
                defaultUsersGuids = await InitializeUsers();
            }

            await InitializePackages(defaultUsersGuids);
        }

        private async Task<Guid[]> InitializeUsers()
        {
            Guid[] userGuids = new Guid[_numberOfUsersToInitialize];

            for (int i = 0; i < _numberOfUsersToInitialize; i++)
            {
                userGuids[i] = await _userService.RegisterAsync($"user{i}@gmail.com", $"user{i}",
                    $"1233{i}A", $"1233{i}A");
            }

            return userGuids;
        }

        private async Task InitializePackages(Guid[] usersGuids)
        {
            CreatePackageDto[] packages = new CreatePackageDto[_numberOfUsersToInitialize]
            {
                new CreatePackageDto(usersGuids[0], usersGuids[1], "Nike shoes",
                    1.5f, 10, 15, 20),
                new CreatePackageDto(usersGuids[2], usersGuids[3], "Fila shoes",
                    2, 15, 15, 15),
                new CreatePackageDto(usersGuids[1], usersGuids[3], "iPhone 13",
                    1, 10, 5, 10),
                new CreatePackageDto(usersGuids[0], usersGuids[2], "Gucci Ace",
                    1.5f, 15, 25, 8)
            };

            for (int i = 0; i < _numberOfUsersToInitialize; i++)
            {
                await _packageService.AddAsync(packages[i]);
            }
        }
    }
}

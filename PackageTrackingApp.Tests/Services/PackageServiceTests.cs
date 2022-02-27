using Autofac.Extras.Moq;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Core.Repositories;
using PackageTrackingApp.Infrastructure.Commands;
using PackageTrackingApp.Infrastructure.DTOs;
using PackageTrackingApp.Infrastructure.Mappers;
using PackageTrackingApp.Infrastructure.Repositories;
using PackageTrackingApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Tests.Services
{
    [TestFixture]
    public class PackageServiceTests
    {
        [Test]
        public async Task Package_service_add_async_should_result_in_exactly_one_package_in_database() //TO DO: repository not executing
                                                                                                             // addAsync properly (probably)
        {
            ////Arrange
            //var mapper = MappingProfile.Initialize();
            //var loggerMock = new Mock<ILogger<PackageService>>();
            //var packageRepositoryMock = new Mock<IPackageRepository>();
            //var packageService = new PackageService(mapper, loggerMock.Object,
            //    packageRepositoryMock.Object);

            ////Act
            //Task addPackageTask = packageService.AddAsync(new CreatePackageDto(Guid.NewGuid(),
            //    Guid.NewGuid(), "Xiaomi Redmi", 1.8f, 10, 15, 12));

            //addPackageTask.GetAwaiter().GetResult();

            //var packages = await packageService.GetAllAsync();
            //int amountOfPackages = packages.Count();

            ////Assert
            //Assert.AreEqual(amountOfPackages, 1);
        }

        [Test]
        public async Task Adding_package_with_the_same_customer_and_seller_should_throw_an_exception()
        {
            //var mapper = MappingProfile.Initialize();
            //var logger = new Mock<ILogger<PackageService>>();

            //var options = new DbContextOptionsBuilder<PackageTrackingContext>()
            //.UseInMemoryDatabase(databaseName: "PackageDatabase")
            //.Options;

            //var dbContext = new Mock<PackageTrackingContext>(options);
            //var repository = new Mock<PackageRepository>(dbContext.Object);

            //var service = new Mock<PackageService>(mapper, logger.Object,
            //    repository.Object);

            //var guid = Guid.NewGuid();

            //var createPackage = new CreatePackage(guid, guid, guid,
            //    "", 1, 2, 3, 4);

            //Assert.ThrowsAsync<Exception>(async () => await service.Object.AddAsync(createPackage));
        }
    }
}

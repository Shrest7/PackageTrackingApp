using Autofac.Extras.Moq;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.DTOs;
using PackageTrackingApp.Infrastructure.Mappers;
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
        private PackageTrackingContext _dbContext;
        private readonly string connectionString = 
            "Server=(localdb)\\mssqllocaldb;Database=PackageTrackingDb;Trusted_Connection=True;";

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<PackageTrackingContext>()
                .UseSqlServer(connectionString)
                .Options;

            _dbContext = new PackageTrackingContext(dbContextOptions);
        }

        [Test]
        public async Task Package_service_add_async_should_call_package_tracking_context_add_async_exactly_once()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<PackageTrackingContext>()
                          .UseInMemoryDatabase("packageTrackingDbTest")
                          .Options;

            IMapper mapper = MappingProfile.Initialize();
            var loggerMock = new Mock<ILogger<PackageService>>();
            var dbContext = new PackageTrackingContext(options);
            //var packageService = new PackageService(mapper,
                //dbContext, loggerMock.Object);

            //Act
            //await packageService.AddAsync(new CreatePackageDto()
            //{
            //    CustomerFirstName = "Mikev22",
            //    CustomerLastName = "Wazowskiv2",
            //    Height = 10,
            //    Length = 10,
            //    Name = "Asus laptopv2",
            //    SellerFirstName = "Johnv2",
            //    SellerLastName = "Dashv2",
            //    Weight = 3,
            //    Width = 15
            //});

            //Assert
            Assert.AreEqual(1, dbContext.Packages.Count());
        }
    }
}

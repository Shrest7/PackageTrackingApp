using Autofac.Extras.Moq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PackageTrackingApp.Core.Domain;
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
        public void Test()
        {
            //var packageService = new PackageService()
            //true.Should().BeTrue();
        }
    }
}

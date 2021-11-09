using NUnit.Framework;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Tests
{
    [TestFixture]
    class InMemoryPackageRepositoryTests
    {
        [Test]
        public void AddingPackageShouldWork()
        {
            //Arrange
            InMemoryPackageRepository _repository = new InMemoryPackageRepository();
            int packagesCount = _repository.packages.Count;
            Package package = new Package(new Customer("Josh", "Smith"),
                new Seller("mail@gmail.com", "222333444"), "phone", 5, 3, 2, 1);

            //Act
            _repository.Add(package);

            //Assert
            Assert.True(_repository.packages.Count == packagesCount + 1);
        }

        [Test]
        public void Providin()
        {
            //Arrange
            InMemoryPackageRepository _repository = new InMemoryPackageRepository();
            var existingPackage = _repository.packages.First();

            //Act

            //Assert
            Assert.Throws<Exception>(() => _repository.Add(existingPackage));
        }
    }
}

using NUnit.Framework;
using PackageTrackingApp.Core.Domains;
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
            Package package = new Package(Guid.NewGuid(), //TODO, GENERALLY ALL TESTS
                Guid.NewGuid(), "phone", 5, 3, 2, 1);

            //Act

        }
    }
}

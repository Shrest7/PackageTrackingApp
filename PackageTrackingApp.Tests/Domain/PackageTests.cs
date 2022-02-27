using FluentAssertions;
using NUnit.Framework;
using PackageTrackingApp.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Tests.Domain
{
    [TestFixture]
    class PackageTests
    {
        [Test]
        public void PackageConstructor_ShouldThrowAnException()
        {
            //Package too big (not anymore prob xD)
            Assert.Throws<ArgumentException>(() => new Package(Guid.NewGuid(), Guid.NewGuid(),
                Guid.NewGuid(), null, 1, 75, 90, 25));
        }

        [Test]
        public void PackageConstructor_ShouldPass()
        {
            Assert.DoesNotThrow(() => new Package(Guid.NewGuid(), Guid.NewGuid(),
                Guid.NewGuid(), null, 1.5f, 10, 15, 25));
        }

        [Test]
        public void PackageConstructor_TwoSameGuidsShouldThrowAnException()
        {

        }
    }
}

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
            Assert.Throws<ArgumentException>(() => new Package(new User(), new User(),
                null, 1, 75, 90, 25));
        }

        [Test]
        public void PackageConstructor_ShouldPass()
        {
            Assert.Throws<ArgumentException>(() => new Package(new User(), new User(),
                null, 1.5f, 10, 15, 25));
        }
    }
}

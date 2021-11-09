using NUnit.Framework;
using PackageTrackingApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void IsEmailShouldFail()
        {
            //Arrange
            string wrongEmail = "@@@@@..pl";

            //Act

            //Assert
            Assert.False(wrongEmail.IsEmail());
        }

        [Test]
        public void IsEmailShouldWork()
        {
            //Arrange
            string correctEmail = "test@gmail.com";

            //Act

            //Assert
            Assert.True(correctEmail.IsEmail());
        }
    }
}

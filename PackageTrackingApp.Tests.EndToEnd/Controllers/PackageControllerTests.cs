using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using PackageTrackingApp.Api;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Tests.EndToEnd.Controllers
{
    [TestFixture]
    public class PackageControllerTests
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;
        public PackageControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Test]
        public async Task Given_valid_guid_http_get_should_work()
        {
            Guid guid = new Guid("23bc4673-0c0a-4fbd-95fc-ba316b336fa4");

            var response = await _client.GetAsync($"package/{guid}");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task Given_invalid_guid_http_get_should_fail()
        {
            Guid guid = new Guid("11111111-2222-3333-4444-555555555555");

            var response = await _client.GetAsync($"package/{guid}");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Test]
        public async Task Posting_valid_package_should_work()
        {
            var createPackageDto = new CreatePackageDto()
            {
                //CustomerFirstName = "Mike",
                //CustomerLastName = "Wazowski",
                Height = 10,
                Length = 10,
                Name = "Asus laptop",
                //SellerFirstName = "John",
                //SellerLastName = "Dash",
                Weight = 3,
                Width = 15
            };

            //var createPackageDto = new Package
            //    (
            //                    CustomerFirstName = "Mike",
            //    CustomerLastName = "Wazowski",
            //    Height = 10,
            //    Length = 10,
            //    Name = "Asus laptop",
            //    SellerFirstName = "John",
            //    SellerLastName = "Dash",
            //    Weight = 3,
            //    Width = 15
            //    );


            var content = ConvertObjectToStringContent(createPackageDto);

            var response = await _client.PostAsync("package", content);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }

        private async Task GetPackageAsync(Guid guid)
        {
            var response = await _client.GetAsync($"package/{guid}");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            //return response.Content
        }

        private StringContent ConvertObjectToStringContent(object obj)
        {
            var content = JsonConvert.SerializeObject(obj);

            return new StringContent(content, Encoding.UTF8, "application/json");
        }
    }
}

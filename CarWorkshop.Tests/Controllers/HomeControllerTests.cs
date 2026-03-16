using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarWorkshop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace CarWorkshop.Controllers.Tests
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private WebApplicationFactory<Program> _factory;

        public HomeControllerTests(WebApplicationFactory<Program> factory)
        {

            _factory = factory;
        }
        [Fact()]
        public async Task About_ReturnsViewWithRenderModel()
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync("/Home/About");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("<h1>About Us</h1>")
                .And.Contain("<h2>We are a leading car workshop providing top-notch services.</h2>")
                .And.Contain("<li>Car Repair</li>")
                .And.Contain("<li>Maintenance</li>")
                .And.Contain("<li>Service</li>");

        }
    }
}
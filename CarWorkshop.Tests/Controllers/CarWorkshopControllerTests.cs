using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using CarWorkshop.Controllers;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarWorkshop.Controllers.Tests
{
    public class CarWorkshopControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
       private readonly WebApplicationFactory<Program> _factory;

        public CarWorkshopControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingWorkshop()
        {
            // arrange
            var carWorkshops = new List<CarWorkshopDto>()
            {
                new CarWorkshopDto()
                {
                    Name = "Test1",
                },
                new CarWorkshopDto()
                {
                    Name = "Test2",
                },
                new CarWorkshopDto()
                {
                    Name = "Test3",
                }
            };
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCarWorkshopsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(carWorkshops);


            var client = _factory
                .WithWebHostBuilder(builder => 
                builder.ConfigureTestServices(services => services.AddScoped(_ => mediatorMock.Object)))
                .CreateClient();
            //act
            var response = await client.GetAsync("/CarWorkshop/Index");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("<h1>Car Workshops</h1>")
                .And.Contain("Test1")
                .And.Contain("Test2")
                .And.Contain("Test3");

        }
    }
}
using Xunit;
using CarWorkshop.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CarWorkshop.Application.ApplicationUser;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using CarWorkshop.Application.CarWorkshop;
using FluentAssertions;

namespace CarWorkshop.Application.Mappings.Tests
{
    public class CarWorkshopMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapCarWorkshopDtotoCarWorkshop()
        {
            //arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock
                .Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test,com", new[] { "Moderator" }));

            var configuration = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object));
            });

            var mapper = configuration.CreateMapper();



            var carWorkshopDto = new CarWorkshopDto
            {
                City = "City",
                PostalCode = "12345",
                Street = "Street",
                PhoneNumber = "1234567890"
            };

            //act
            var result = mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);

            //assert

            result.Should().NotBeNull();
            result.ContactDetails.Should().NotBeNull();
            result.ContactDetails.City.Should().Be(carWorkshopDto.City);
            result.ContactDetails.PostalCode.Should().Be(carWorkshopDto.PostalCode);
            result.ContactDetails.Street.Should().Be(carWorkshopDto.Street);
            result.ContactDetails.PhoneNumber.Should().Be(carWorkshopDto.PhoneNumber);


        }

        [Fact()]
        public void MappingProfile_ShouldMapCarWorkshopToCarWorkshopDto()
        {
            //arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock
                .Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test,com", new[] { "Moderator" }));
            var configuration = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object));
            });
            var mapper = configuration.CreateMapper();
            var carWorkshop = new Domain.Entities.CarWorkshop
            {
                Id = 1,
                CreatedById = "1",
                ContactDetails = new Domain.Entities.CarWorkshopContactDetalis
                {
                    City = "City",
                    PostalCode = "12345",
                    Street = "Street",
                    PhoneNumber = "1234567890"
                }
            };
            //act
            var result = mapper.Map<CarWorkshopDto>(carWorkshop);
            //assert
            result.Should().NotBeNull();
            result.IsEditable.Should().BeTrue();
            result.City.Should().Be(carWorkshop.ContactDetails.City);
            result.PostalCode.Should().Be(carWorkshop.ContactDetails.PostalCode);
            result.Street.Should().Be(carWorkshop.ContactDetails.Street);
            result.PhoneNumber.Should().Be(carWorkshop.ContactDetails.PhoneNumber);
        }
    }
}
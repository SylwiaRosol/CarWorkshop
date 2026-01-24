using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Mappings
{
    public class CarWorkshopMappingProfile : Profile
    {
        public CarWorkshopMappingProfile()
        {
            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                 .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetalis()
                 {
                        PhoneNumber = src.PhoneNumber,
                        Street = src.Street,
                        City = src.City,
                        PostalCode = src.PostalCode

                 }));

            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode));
        }
    }
}

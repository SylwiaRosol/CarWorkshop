using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Services
{
    public class CarWorkshopServices : ICarWorkshopServices
    {
        private readonly ICarWorkshopRespository _carWorkshopRepository;
        private readonly IMapper _mapper;
        public CarWorkshopServices(ICarWorkshopRespository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }
        public async Task Create(CarWorkshopDto carWorkshopDto)
        {
           var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);
            // Business logic for creating a car workshop
            carWorkshop.EncodeName();
            // Save to database logic would go here
            await _carWorkshopRepository.Create(carWorkshop);
        }
        public async Task<IEnumerable<CarWorkshopDto>> GetAll()
        {
            var carWorkshops = await _carWorkshopRepository.GetAll();
            return _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);
        }
    }
}

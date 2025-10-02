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
        public CarWorkshopServices(ICarWorkshopRespository carWorkshopRepository)
        {
            _carWorkshopRepository = carWorkshopRepository;
        }
        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            // Business logic for creating a car workshop
            carWorkshop.EncodeName();
            // Save to database logic would go here
            await _carWorkshopRepository.Create(carWorkshop);
        }
    }
}

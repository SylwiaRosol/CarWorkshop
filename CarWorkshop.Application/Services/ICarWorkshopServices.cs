





using CarWorkshop.Application.CarWorkshop;

namespace CarWorkshop.Application.Services
{
    public interface ICarWorkshopServices
    {
        Task Create(CarWorkshopDto carWorkshop);
        Task<IEnumerable<CarWorkshopDto>> GetAll();
    }
}
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Services;
using CarWorkshop.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopServices _carWorkshopServices;
        public CarWorkshopController(ICarWorkshopServices carWorkshopServices)
        {
            _carWorkshopServices = carWorkshopServices;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDto carWorkshop)
        {
           if(!ModelState.IsValid)
                { 
                return View(carWorkshop); 
                }
            await _carWorkshopServices.Create(carWorkshop);
            return RedirectToAction(nameof(Create));
        }
    }
}

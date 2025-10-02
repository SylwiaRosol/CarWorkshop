﻿using CarWorkshop.Application.Services;
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

        [HttpPost]
        public async Task<IActionResult> Create(Domain.Entities.CarWorkshop carWorkshop)
        {
           await _carWorkshopServices.Create(carWorkshop);
            return RedirectToAction(nameof(Create));
        }
    }
}

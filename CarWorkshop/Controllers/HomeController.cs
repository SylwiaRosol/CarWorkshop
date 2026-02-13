using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Models;

namespace CarWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult NoAccess()
    {
        return View();
    }
    public IActionResult About()
    {
        var model = new About
        {
            Title = "About Us",
            Description = "We are a leading car workshop providing top-notch services.",
            Tags = new List<string> { "Car Repair", "Maintenance", "Service" }
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;
using WebApp_SolarIOT.Areas.Identity.Data;
using WebApp_SolarIOT.Data;
using WebApp_SolarIOT.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WebApp_SolarIOT.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var data = await _context.parameters

           .OrderByDescending(p => p.EventProcessedUtcTime)
           .Select(p => new { p.battery_volt, p.solar_amp, p.temperature, p.light_intensity, p.EventProcessedUtcTime })
           .Take(10)
           .ToListAsync();

            var batteryVoltData = data.Select(d => d.battery_volt).ToArray();
            var solarAmpData = data.Select(d => d.solar_amp).ToArray();
            var temperatureData = data.Select(d => d.temperature).ToArray();
            var lightIntensityData = data.Select(d => d.light_intensity).ToArray();
            var eventTimeData = data.Select(d => d.EventProcessedUtcTime.ToString("MM/dd/yyyy HH:mm:ss")).ToArray();

            Array.Reverse(batteryVoltData);
            Array.Reverse(solarAmpData);
            Array.Reverse(temperatureData);
            Array.Reverse(lightIntensityData);
            Array.Reverse(eventTimeData);

            ViewBag.BatteryVoltData = batteryVoltData;
            ViewBag.SolarAmpData = solarAmpData;
            ViewBag.TemperatureData = temperatureData;
            ViewBag.LightIntensityData = lightIntensityData;
            ViewBag.EventTimeData = eventTimeData;

            var latestParameters = await _context.parameters
               .OrderByDescending(p => p.EventProcessedUtcTime)
               .FirstOrDefaultAsync();

            if (latestParameters == null)
            {
                return NotFound("No latest parameters found.");
            }

            return View(latestParameters);
        }

        public IActionResult Privacy()
        {
            ViewData["UserID"]= _userManager.GetUserId(this.User);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using WeatherAspNet.Services;

namespace WeatherAspNet.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IActionResult Forcast()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Forcast(string newCityName)
        {
            ViewData["NewCityName"] = newCityName;
            return View();

        }
    }
}
using Microsoft.AspNetCore.Mvc;
using WeatherAspNet.Models.ViewComponents;
using WeatherAspNet.Models.ViewModels;
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
            //_weatherService.GetCity();

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
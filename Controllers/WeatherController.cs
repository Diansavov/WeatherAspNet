using Microsoft.AspNetCore.Mvc;
using WeatherAspNet.Models;
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
        public async Task<JsonResult> Coordinates()
        {
            string? cityName = Request.Cookies["LastCity"];

            WeatherData city = await _weatherService.GetCity(cityName);
            JsonResult jsonResult = Json(city.Coord);
            
            return jsonResult;
        }
    }
}
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WeatherAspNet.Models.ViewModels;
using WeatherAspNet.Services;

namespace WeatherAspNet.Models.ViewComponents
{
    [ViewComponent]
    public class CityTemperatureViewComponent : ViewComponent
    {
        private readonly IWeatherService _weatherService;
        private WeatherData weatherData;

        public CityTemperatureViewComponent(IWeatherService weatherService)
        {
            _weatherService = weatherService;
            weatherData = new WeatherData();
        }
        public async Task<IViewComponentResult> InvokeAsync(string newCityName)
        {
            string? cityName = Request.Cookies["LastCity"];
            if (cityName == null)
            {
                HttpContext.Response.Cookies.Delete("LastCity");

                CookieOptions cookieOptions = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(1)
                };
                HttpContext.Response.Cookies.Append("LastCity", "Sofia", cookieOptions);
                cityName = "Sofia";
            }

            weatherData = await _weatherService.GetCity(newCityName);
            if (weatherData == null)
            {
                weatherData = await _weatherService.GetCity(cityName);
            }
            else
            {
                HttpContext.Response.Cookies.Delete("LastCity");

                CookieOptions cookieOptions = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(1)
                };
                HttpContext.Response.Cookies.Append("LastCity", newCityName, cookieOptions);
            }
            CityTemperature city = new CityTemperature(weatherData);

            return await Task.FromResult((IViewComponentResult)View("CityTemperature", city));

        }
    }
}
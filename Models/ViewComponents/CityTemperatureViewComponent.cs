using Microsoft.AspNetCore.Mvc;
using WeatherAspNet.Models.ViewModels;
using WeatherAspNet.Services;

namespace WeatherAspNet.Models.ViewComponents
{
    [ViewComponent]
    public class CityTemperatureViewComponent : ViewComponent
    {
        private readonly IWeatherService _weatherService;


        public CityTemperatureViewComponent(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string newCityName)
        {
            WeatherData weatherData = new WeatherData();
            if (newCityName != null)
            {
                weatherData = await _weatherService.GetCity(newCityName);
            }
            else
            {
                weatherData = await _weatherService.GetCity("Sofia");
            }
            CityTemperature city = new CityTemperature(weatherData);

            return await Task.FromResult((IViewComponentResult)View("CityTemperature", city));
        }
    }
}
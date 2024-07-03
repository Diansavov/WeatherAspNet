using Microsoft.AspNetCore.Mvc;
using WeatherAspNet.Models.ViewModels;
using WeatherAspNet.Services;

namespace WeatherAspNet.Models.ViewComponents
{
    [ViewComponent]
    public class CityTemperatureViewComponent : ViewComponent
    {
        private readonly IWeatherService _weatherService;
        private string cityName;
        public string CityName
        {
            get { return cityName; }
            set
            {
                if (cityName == null)
                {
                    cityName = "Veliko Tarnovo";
                }
                cityName = value;
            }
        }

        public CityTemperatureViewComponent(IWeatherService weatherService, string newCityName)
        {
            _weatherService = weatherService;
            cityName = newCityName;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            WeatherData weatherData = await _weatherService.GetCity(cityName);
            CityTemperature city = new CityTemperature(weatherData);

            return await Task.FromResult((IViewComponentResult)View("CityTemperature", city));
        }
    }
}
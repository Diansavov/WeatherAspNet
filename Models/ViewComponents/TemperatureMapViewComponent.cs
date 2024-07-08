using System.Net;
using Microsoft.AspNetCore.Mvc;
using WeatherAspNet.Models.ViewModels;
using WeatherAspNet.Services;

namespace WeatherAspNet.Models.ViewComponents
{
    [ViewComponent]
    public class TemperatureMapViewComponent : ViewComponent
    {
        private readonly IWeatherService _weatherService;

        public TemperatureMapViewComponent(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("TemperatureMap"));
        }
    }
}
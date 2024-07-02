using WeatherAspNet.Models;

namespace WeatherAspNet.Services
{
    
    public interface IWeatherService
    {
        Task<WeatherData> GetCity(string cityName);
    }
}
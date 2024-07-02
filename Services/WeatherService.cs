
using Newtonsoft.Json;
using WeatherAspNet.Models;

namespace WeatherAspNet.Services
{
    class WeatherService : IWeatherService
    {
        public async Task<WeatherData> GetCity(string cityName)
        {
            HttpClient httpClient = new HttpClient();
            string apiKey = "fe747b888173572352b880928ec52948";
            HttpResponseMessage response = await httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherData city = JsonConvert.DeserializeObject<WeatherData>(content);
            
                return city;
            }
            else
            {
                return null;
            }
        }
    }
}
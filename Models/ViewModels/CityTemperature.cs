namespace WeatherAspNet.Models.ViewModels
{
    class CityTemperature
    {

        public CityTemperature(WeatherData weatherData)
        {
            CityName = weatherData.Name;
            CityTemp = weatherData.Main.TempCelsius;
            IconUrl = "https://openweathermap.org/img/wn/" + weatherData.Weather[0].Icon + ".png";
        }
         public string CityName { get; set; }
         public double CityTemp { get; set; }
         public string IconUrl { get; set; }
    }
}
namespace WeatherAspNet.Models.ViewModels
{
    public class CityTemperature
    {

        public CityTemperature(WeatherData weatherData)
        {
            CityName = weatherData.Name;
            CountryCode = weatherData.Sys.Country;
            CityTemp = weatherData.Main.TempCelsius;
            CityTempFeelsLike = weatherData.Main.Feels_Like - 273.15f;
            IconUrl = "https://openweathermap.org/img/wn/" + weatherData.Weather[0].Icon + ".png";

            Weather = new Weather();
            Weather.Main = weatherData.Weather[0].Main;
            Weather.Description = weatherData.Weather[0].Description;
        }
        public string CityName { get; set; }
        public double CityTemp { get; set; }
        public string CountryCode { get; set; }
        public double CityTempFeelsLike { get; set; }
        public string IconUrl { get; set; }
        public Weather Weather { get; set; }
    }
    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }
}
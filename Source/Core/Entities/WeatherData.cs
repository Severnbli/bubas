using bubas.Source.Core.Enums;

namespace bubas.Source.Core.Entities;

public class WeatherData
{
    public long Id { get; set; }
    public WeatherProviders WeatherProvider { get; set; } = WeatherProviders.OpenWeatherMap;
}
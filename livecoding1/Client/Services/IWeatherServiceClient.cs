using BlazorGrpc.Shared;

namespace BlazorGrpc.Client.Services;

public interface IWeatherServiceClient
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();
}
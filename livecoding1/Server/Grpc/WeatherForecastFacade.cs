using BlazorGrpc.Server.Services;
using BlazorGrpc.Shared;

namespace BlazorGrpc.Server.Grpc;

public class WeatherForecastFacade : IWeatherForecastFacade
{
    private readonly WeatherForecastService _weatherForecastService;

    public WeatherForecastFacade(WeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }
    public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync()
    {
        return await _weatherForecastService.GetWeatherForecastsAsync();
    }
}
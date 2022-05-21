using ProtoBuf.Grpc.Configuration;

namespace BlazorGrpc.Shared;

[Service]
public interface IWeatherForecastFacade
{
    Task<IEnumerable<WeatherForecast>> GetForecastsAsync();
}
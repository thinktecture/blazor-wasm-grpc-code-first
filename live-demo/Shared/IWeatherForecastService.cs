using ProtoBuf.Grpc.Configuration;

namespace BlazorWasmGrpcCodeFirst.Shared
{
    [Service]
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetAsync();
    }
}
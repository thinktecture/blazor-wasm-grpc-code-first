using ProtoBuf.Grpc.Configuration;

namespace BlazorWasmGrpcCodeFirst.Shared
{
    [Service]
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}
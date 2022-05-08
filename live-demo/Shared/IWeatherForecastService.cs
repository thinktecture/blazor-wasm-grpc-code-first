using ProtoBuf.Grpc.Configuration;

namespace BlazorWasmGrpcCodeFirst.Shared
{
    [Service]
    public interface IWeatherForecastService
    {
#pragma warning disable PBN2008
        Task<IEnumerable<WeatherForecast>> GetAsync();
#pragma warning restore PBN2008
    }
}
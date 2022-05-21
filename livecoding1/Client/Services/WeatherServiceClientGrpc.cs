using BlazorGrpc.Shared;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace BlazorGrpc.Client.Services;

public class WeatherServiceClientGrpc : IWeatherServiceClient
{
    private readonly IWeatherForecastFacade _serviceClient;

    public WeatherServiceClientGrpc(GrpcChannel channel)
    {
        _serviceClient = channel.CreateGrpcService<IWeatherForecastFacade>();
    }
    
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
    {
        return await _serviceClient.GetForecastsAsync();
    }
}
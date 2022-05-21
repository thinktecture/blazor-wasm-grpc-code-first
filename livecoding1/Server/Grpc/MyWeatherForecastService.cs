using BlazorGrpc.Server.Proto;
using BlazorGrpc.Server.Services;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace BlazorGrpc.Server.Grpc;

public class MyWeatherForecastGrpcService :  MyWeatherForecastService.MyWeatherForecastServiceBase
{
    private readonly WeatherForecastService _weatherForecastService;

    public MyWeatherForecastGrpcService(WeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    public override async Task<WeatherForecastResponse> GetForecast(WeatherForecastRequest request, ServerCallContext context)
    {
        var forecasts = await _weatherForecastService.GetWeatherForecastsAsync();
        var result = forecasts.Select(wfc => new WeatherForecastResult
        {
            Date = Timestamp.FromDateTime(wfc.Date),
            TemperatureC = wfc.TemperatureC,
            Summary = wfc.Summary
        });
            
        var response = new WeatherForecastResponse();
        response.WeatherForecasts.AddRange(result);

        return response;
    }
}
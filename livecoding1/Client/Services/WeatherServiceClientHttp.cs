using System.Net.Http.Json;
using BlazorGrpc.Shared;

namespace BlazorGrpc.Client.Services;

public class WeatherServiceClientHttp : IWeatherServiceClient
{
    private readonly HttpClient _httpClient;

    public WeatherServiceClientHttp(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast") ?? Array.Empty<WeatherForecast>();
    }
}
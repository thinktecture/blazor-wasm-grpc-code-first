using System.Net.Http.Json;
using BlazorGrpc.Shared;

namespace BlazorGrpc.Client.Services;

public class WeatherServiceClient : IWeatherServiceClient
{
    private readonly HttpClient _httpClient;

    public WeatherServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast");
    }
}
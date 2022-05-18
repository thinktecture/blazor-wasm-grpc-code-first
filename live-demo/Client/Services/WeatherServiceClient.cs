using System;
using System.Net.Http.Json;
using BlazorWasmGrpcCodeFirst.Shared;

namespace BlazorWasmGrpcCodeFirst.Client.Services
{
	public class WeatherServiceClient : IWeatherServiceClient
	{
        private HttpClient _httpClient;

		public WeatherServiceClient(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync()
        {
            return (await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast"))!;
        }
    }
}

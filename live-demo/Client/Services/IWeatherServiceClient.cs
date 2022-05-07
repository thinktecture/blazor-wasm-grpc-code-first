using System;
using BlazorWasmGrpcCodeFirst.Shared;

namespace BlazorWasmGrpcCodeFirst.Client.Services
{
	public interface IWeatherServiceClient
	{
		public Task<ICollection<WeatherForecast>> GetWeatherForecastAsync();
	}
}

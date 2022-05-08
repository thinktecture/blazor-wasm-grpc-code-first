using System;
using System.Collections.ObjectModel;
using BlazorWasmGrpcCodeFirst.Shared;
using Google.Protobuf.WellKnownTypes;

namespace BlazorWasmGrpcCodeFirst.Server.GrpcServices
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastService()
        {
        }

        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var rng = new Random();

            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.UtcNow.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            return await Task.FromResult(forecasts);
        }
    }
}

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static BlazorWasmGrpcCodeFirst.Server.WeatherService;

namespace BlazorWasmGrpcCodeFirst.Server.GrpcServices
{
	public class WeatherService : WeatherServiceBase
	{
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public override async Task<WeatherForecastResponse> GetForecast(WeatherForecastRequest request, ServerCallContext context)
        {
            var rng = new Random();

            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecastResult
            {
                Date = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(index)),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            var response = new WeatherForecastResponse();
            response.WeatherForecasts.AddRange(forecasts);

            return await Task.FromResult(response);
        }
    }
}

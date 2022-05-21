using BlazorGrpc.Server.Services;
using Microsoft.AspNetCore.Mvc;
using BlazorGrpc.Shared;

namespace BlazorGrpc.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _weatherService;

        public WeatherForecastController(WeatherForecastService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync()
        {
            return await _weatherService.GetWeatherForecastsAsync();
        }
    }
}

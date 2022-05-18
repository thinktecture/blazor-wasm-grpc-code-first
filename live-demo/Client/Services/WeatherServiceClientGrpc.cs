using BlazorWasmGrpcCodeFirst.Shared;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace BlazorWasmGrpcCodeFirst.Client.Services
{
	public class WeatherServiceClientGrpc : IWeatherServiceClient
	{
        private IWeatherForecastService _serviceClient;

		public WeatherServiceClientGrpc(GrpcChannel grpcChannel)
		{
            _serviceClient = grpcChannel.CreateGrpcService< IWeatherForecastService>();
		}

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync()
        {
            return await _serviceClient.GetAsync();
        }
    }
}

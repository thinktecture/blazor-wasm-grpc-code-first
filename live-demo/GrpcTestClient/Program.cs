using BlazorWasmGrpcCodeFirst.Server;
using Grpc.Net.Client;
using static BlazorWasmGrpcCodeFirst.Server.WeatherService;

Console.WriteLine("Press a key to start...");
Console.ReadKey();

var channel = GrpcChannel.ForAddress("http://localhost:5000");

var client = new WeatherServiceClient(channel);
var response = client.GetForecast(new WeatherForecastRequest());

Console.WriteLine(response.WeatherForecasts.Count);
Console.ReadLine();
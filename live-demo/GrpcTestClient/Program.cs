using BlazorWasmGrpcCodeFirst.Server;
using BlazorWasmGrpcCodeFirst.Shared;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using static BlazorWasmGrpcCodeFirst.Server.WeatherService;

Console.WriteLine("Press a key to start...");
Console.ReadKey();

var channel = GrpcChannel.ForAddress("http://localhost:5000");

var client = new WeatherServiceClient(channel);
var response = client.GetForecast(new WeatherForecastRequest());

Console.WriteLine("Contract-first - {0}", response.WeatherForecasts.Count);

var clientProxy = channel.CreateGrpcService<IWeatherForecastService>();
var weatherForecasts = clientProxy.Get();

Console.WriteLine("Code-first - {0}", weatherForecasts.Count());

Console.ReadLine();
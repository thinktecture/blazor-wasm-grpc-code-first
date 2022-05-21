using BlazorGrpc.Server.Proto;
using BlazorGrpc.Shared;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

Console.WriteLine("Press a key to start...");
Console.ReadKey();

var channel = GrpcChannel.ForAddress("http://localhost:5050");

var client = new MyWeatherForecastService.MyWeatherForecastServiceClient(channel);
var response = client.GetForecast(new WeatherForecastRequest());

Console.WriteLine("Contract-first - {0}", response.WeatherForecasts.Count);

var clientProxy = channel.CreateGrpcService<IWeatherForecastFacade>();
var weatherForecasts = await clientProxy.GetForecastsAsync();

Console.WriteLine("Code-first - {0}", weatherForecasts.Count());

Console.ReadLine();

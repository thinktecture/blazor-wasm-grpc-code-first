using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasmGrpcCodeFirst.Client;
using MudBlazor.Services;
using BlazorWasmGrpcCodeFirst.Client.Services;
using Grpc.Net.Client.Web;
using Grpc.Net.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<GrpcChannel>(services =>
{
    var grpcWebHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler());
    var channel = GrpcChannel.ForAddress(builder.HostEnvironment.BaseAddress, new GrpcChannelOptions { HttpHandler = grpcWebHandler });

    return channel;
});

builder.Services.AddScoped<IWeatherServiceClient, WeatherServiceClientGrpc>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
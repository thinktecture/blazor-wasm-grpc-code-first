using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MudBlazor.Services;
using MudBlazor;
using GrpcCodeFirst.Client.Services;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace GrpcCodeFirst.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<GrpcChannel>(services =>
            {
                var grpcWebHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler());
                var channel = GrpcChannel.ForAddress(builder.HostEnvironment.BaseAddress, new GrpcChannelOptions { HttpHandler = grpcWebHandler });

                return channel;
            });

            builder.Services.AddScoped<IConferenceServiceClient, ConferenceServiceGrpcClient>();

            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Grpc.Net.Client;

namespace BlazorWasmGrpcCodeFirst.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<GrpcChannel>(services =>
            {
                var channel = GrpcChannel.ForAddress(builder.HostEnvironment.BaseAddress);

                return channel;
            });

            await builder.Build().RunAsync();
        }
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
using ConfTool.Client.Infrastructure;
using ConfTool.Client.Webcam;
using ConfTool.ClientModules.Conferences;
using ConfTool.ClientModules.Statistics;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfTool.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddConferencesModule(builder.Configuration);
            builder.Services.AddStatisticsModule(builder.Configuration);

            builder.Services.AddWebcam();

            builder.Services.AddScoped<GrpcChannel>(services =>
            {
                var channel = BuildGrpcChannel(services, builder);

                return channel;
            });

            builder.Services.AddScoped<CallInvoker>(services =>
            {
                var channel = BuildGrpcChannel(services, builder);
                var invoker = channel.Intercept(new ClientLoggerInterceptor());

                return invoker;
            });

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Oidc", options.ProviderOptions);
            });
            
            await builder.Build().RunAsync();
        }

        private static GrpcChannel BuildGrpcChannel(IServiceProvider services, WebAssemblyHostBuilder builder)
        {
            var baseAddressMessageHandler = services.GetRequiredService<BaseAddressAuthorizationMessageHandler>();
            baseAddressMessageHandler.InnerHandler = new HttpClientHandler();
            var grpcWebHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, baseAddressMessageHandler);

            var channel = GrpcChannel.ForAddress(builder.Configuration[Configuration.BackendUrlKey], new GrpcChannelOptions { HttpHandler = grpcWebHandler });

            return channel;
        }
    }
}

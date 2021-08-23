using GrpcCodeFirst.Api.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GrpcCodeFirst.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .ConfigureKestrel(options =>
                {
                    // all endpoints without TLS
                    options.ListenLocalhost(5000, o => o.Protocols = HttpProtocols.Http2); // gRPC
                    options.ListenLocalhost(5001, o => o.Protocols = HttpProtocols.Http1AndHttp2); // Web & gRPC-Web
                })
                .UseStartup<Startup>()
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ConferencesDbContext>();
                DataGenerator.Initialize(services);
            }

            return host;
        }
    }
}

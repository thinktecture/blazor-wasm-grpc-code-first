using GrpcCodeFirst.Api;
using Microsoft.Extensions.Hosting;
using NL.Serverless.AspNetCore.AzureFunctionsHost;
using System.Threading.Tasks;

namespace MudBlazorDemoWasm.FunctionApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureWebAppFunctionHost<Startup>()
                .Build();

            await host.RunAsync();
        }
    }
}

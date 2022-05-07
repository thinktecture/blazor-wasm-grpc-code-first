using System;
using ConfTool.ClientModules.Statistics.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfTool.ClientModules.Statistics
{
    public static class StatisticsModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddStatisticsModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<StatisticsServiceClient>();

            services.AddHttpClient("Statistics.ServerAPI.Anon", client =>
                client.BaseAddress = new Uri(config[Configuration.BackendUrlKey]));

            return services;
        }
    }
}

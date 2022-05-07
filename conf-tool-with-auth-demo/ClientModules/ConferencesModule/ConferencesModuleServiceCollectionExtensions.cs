using System;
using Blazored.Toast;
using ConfTool.ClientModules.Conferences.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfTool.ClientModules.Conferences
{
    public static class ConferencesModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddConferencesModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IConferencesServiceClient, ConferencesServiceClientGrpc>();
            services.AddScoped<CountriesServiceClient>();

            services.AddHttpClient("Conferences.ServerAPI", client =>
                client.BaseAddress = new Uri(config[Configuration.BackendUrlKey]))
                    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            services.AddDialog();

            services.AddBlazoredToast();

            return services;
        }
    }
}

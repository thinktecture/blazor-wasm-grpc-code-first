using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ConfTool.ClientModules.Conferences.Services
{
    public class CountriesServiceClient
    {
        private readonly HttpClient _anonHttpClient;
        private readonly string _countriesUrl;

        public CountriesServiceClient(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _anonHttpClient = httpClientFactory.CreateClient("ConfTool.ServerAPI.Anon");
            var baseUrl = config[Configuration.BackendUrlKey];
            _countriesUrl = new Uri(new Uri(baseUrl), "api/countries/").ToString();
        }

        public async Task<List<string>> ListCountries()
        {
            var result = await _anonHttpClient.GetFromJsonAsync<List<string>>(_countriesUrl);

            return result;
        }
    }
}

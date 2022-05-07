using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConfTool.ClientModules.Statistics.Services
{
    public class StatisticsServiceClient
    {
        private readonly HttpClient _anonHttpClient;
        private readonly string _statisticsUrl;

        public StatisticsServiceClient(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _anonHttpClient = httpClientFactory.CreateClient("Statistics.ServerAPI.Anon");
            var baseUrl = config[Configuration.BackendUrlKey];
            _statisticsUrl = new Uri(new Uri(baseUrl), "api/statistics/").ToString();
        }

        public async Task<dynamic> GetStatisticsAsync()
        {
            var result = await _anonHttpClient.GetFromJsonAsync<dynamic>(_statisticsUrl);

            return result;
        }
    }
}

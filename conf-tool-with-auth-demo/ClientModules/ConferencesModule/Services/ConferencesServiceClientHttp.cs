using ConfTool.Shared.DTO;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConfTool.ClientModules.Conferences.Services
{
    public class ConferencesServiceClientHttp : IConferencesServiceClient
    {
        private readonly HttpClient _secureHttpClient;
        private readonly string _baseUrl;
        private readonly string _conferencesUrl;
        private HubConnection _hubConnection;

        public event EventHandler ConferenceListChanged;

        public ConferencesServiceClientHttp(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _secureHttpClient = httpClientFactory.CreateClient("Conferences.ServerAPI");
            _baseUrl = config[Configuration.BackendUrlKey];
            _conferencesUrl = new Uri(new Uri(_baseUrl), "api/conferences/").ToString();
        }

        public async Task InitAsync()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(new Uri(_baseUrl), "conferencesHub"))
                .Build();

            _hubConnection.On("NewConferenceAdded", () =>
            {
                ConferenceListChanged?.Invoke(this, null);
            });

            await _hubConnection.StartAsync();
        }

        public async Task<List<ConferenceOverview>> ListConferencesAsync()
        {
            var result = await _secureHttpClient.GetFromJsonAsync<List<ConferenceOverview>>(_conferencesUrl);

            return result;
        }

        public async Task<ConferenceDetails> GetConferenceDetailsAsync(Guid id)
        {
            var result = await _secureHttpClient.GetFromJsonAsync<ConferenceDetails>(_conferencesUrl + id);

            return result;
        }

        public async Task<ConferenceDetails> AddConferenceAsync(ConferenceDetails conference)
        {
            var result = await (await _secureHttpClient.PostAsJsonAsync<ConferenceDetails>(_conferencesUrl, conference))
                .Content.ReadFromJsonAsync<ConferenceDetails>();

            return result;
        }
    }
}

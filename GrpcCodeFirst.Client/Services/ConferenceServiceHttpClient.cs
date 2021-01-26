using GrpcCodeFirst.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GrpcCodeFirst.Client.Services
{
    public class ConferenceServiceHttpClient : IConferenceServiceClient
    {
        private HttpClient _httpClient;
        private string _conferencesUrl;

        public event EventHandler ConferenceListChanged;

        public ConferenceServiceHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _conferencesUrl = "api/conferences/";
        }

        public async Task<List<ConferenceOverview>> ListConferencesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ConferenceOverview>>(_conferencesUrl);

            return result;
        }

        public async Task<ConferenceDetails> GetConferenceDetailsAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<ConferenceDetails>(_conferencesUrl + id);

            return result;
        }

        public async Task<ConferenceDetails> AddConferenceAsync(ConferenceDetails conference)
        {
            var result = await (await _httpClient.PostAsJsonAsync(_conferencesUrl, conference))
                .Content.ReadFromJsonAsync<ConferenceDetails>();

            return result;
        }

        public Task InitAsync()
        {
            return Task.FromResult(0);
        }
    }
}

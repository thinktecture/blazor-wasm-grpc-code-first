using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfTool.Shared.Contracts;
using ConfTool.Shared.DTO;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Client;

namespace ConfTool.ClientModules.Conferences.Services
{
    public class ConferencesServiceClientGrpc : IConferencesServiceClient
    {
        private readonly IConferencesService _client;
        //private Conference.Conferences.ConferencesClient _client;

        private readonly string _baseUrl;
        private HubConnection _hubConnection;

        public event EventHandler ConferenceListChanged;

        public ConferencesServiceClientGrpc(IConfiguration config, GrpcChannel channel, CallInvoker invoker)
        {
            _baseUrl = config[Configuration.BackendUrlKey];

            //_client = new Conference.Conferences.ConferencesClient(channel);
            _client = channel.CreateGrpcService<IConferencesService>();
            //_client = invoker.CreateGrpcService<IConferencesService>();
        }

        public async Task InitAsync()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(new Uri(_baseUrl), "conferencesHub"))
                .WithAutomaticReconnect()
                .AddMessagePackProtocol()
                .Build();

            _hubConnection.On("NewConferenceAdded", () =>
            {
                ConferenceListChanged?.Invoke(this, null);
            });

            await _hubConnection.StartAsync();
        }

        public async Task<List<ConferenceOverview>> ListConferencesAsync()
        {
            var result = await _client.ListConferencesAsync();

            return result.ToList();
        }

        public async Task<ConferenceDetails> GetConferenceDetailsAsync(Guid id)
        {
            var result = await _client.GetConferenceDetailsAsync(new ConferenceDetailsRequest { ID = id });

            return result;
        }

        public async Task<ConferenceDetails> AddConferenceAsync(ConferenceDetails conference)
        {
            var result = await _client.AddNewConferenceAsync(conference);

            return result;
        }
    }
}

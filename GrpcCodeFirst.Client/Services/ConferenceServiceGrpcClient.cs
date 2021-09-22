using Grpc.Net.Client;
using GrpcCodeFirst.Shared.DTO;
using GrpcCodeFirst.Shared.Interfaces;
using ProtoBuf.Grpc.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcCodeFirst.Client.Services
{
    public class ConferenceServiceGrpcClient : IConferenceServiceClient
    {
        private readonly IConferenceService _serviceClient;

        public ConferenceServiceGrpcClient(GrpcChannel channel)
        {
            _serviceClient = channel.CreateGrpcService<IConferenceService>();
        }

        public async Task<List<ConferenceOverview>> ListConferencesAsync()
        {
            var result = await _serviceClient.ListConferencesAsync();

            return result.ToList();
        }

        public async Task<ConferenceDetails> GetConferenceDetailsAsync(Guid id)
        {
            var result = await _serviceClient.GetConferenceDetailsAsync(new ConferenceDetailsRequest { Id = id });

            return result;
        }

        public async Task<ConferenceDetails> AddConferenceAsync(ConferenceDetails conference)
        {
            var result = await _serviceClient.AddNewConferenceAsync(conference);

            return result;
        }
    }
}

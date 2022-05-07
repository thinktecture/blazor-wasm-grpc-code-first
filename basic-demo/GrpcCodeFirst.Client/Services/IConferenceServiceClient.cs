using GrpcCodeFirst.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcCodeFirst.Client.Services
{
    public interface IConferenceServiceClient
    {
        Task<List<ConferenceOverview>> ListConferencesAsync();
        Task<ConferenceDetails> AddConferenceAsync(ConferenceDetails conference);
        Task<ConferenceDetails> GetConferenceDetailsAsync(Guid id);
    }
}

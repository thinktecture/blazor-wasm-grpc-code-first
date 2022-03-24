using GrpcCodeFirst.Shared.DTO;
using ProtoBuf.Grpc.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcCodeFirst.Shared.Interfaces
{
    [Service]
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceOverview>> ListConferencesAsync();
        Task<ConferenceDetails> GetConferenceDetailsAsync(ConferenceDetailsRequest request);
        Task<ConferenceDetails> AddNewConferenceAsync(ConferenceDetails conference);
    }
}

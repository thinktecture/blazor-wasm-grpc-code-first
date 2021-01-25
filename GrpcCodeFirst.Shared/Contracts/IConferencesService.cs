using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcCodeFirst.Shared.DTO;

namespace GrpcCodeFirst.Shared.Contracts
{
    public interface IConferencesService
    {
        Task<IEnumerable<ConferenceOverview>> ListConferencesAsync();
        Task<ConferenceDetails> GetConferenceDetailsAsync(ConferenceDetailsRequest request);
        Task<ConferenceDetails> AddNewConferenceAsync(ConferenceDetails conference);
    }
}
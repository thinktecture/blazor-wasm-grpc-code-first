using GrpcCodeFirst.Shared.DTO;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GrpcCodeFirst.Shared.Interfaces
{
    [ServiceContract]
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceOverview>> ListConferencesAsync();
        Task<ConferenceDetails> GetConferenceDetailsAsync(ConferenceDetailsRequest request);
        Task<ConferenceDetails> AddNewConferenceAsync(ConferenceDetails conference);
    }
}

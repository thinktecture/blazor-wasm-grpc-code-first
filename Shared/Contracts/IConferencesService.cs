using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using BlazorWasmGrpcCodeFirst.Shared.DTO;

namespace BlazorWasmGrpcCodeFirst.Shared.Contracts
{
    [ServiceContract]
    public interface IConferencesService
    {
        Task<IEnumerable<ConferenceOverview>> ListConferencesAsync();
        Task<ConferenceDetails> GetConferenceDetailsAsync(ConferenceDetailsRequest request);
        Task<ConferenceDetails> AddNewConferenceAsync(ConferenceDetails conference);
    }
}
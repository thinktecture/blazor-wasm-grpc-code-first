using AutoMapper;
using GrpcCodeFirst.Api.GrpcServices.Interfaces;
using GrpcCodeFirst.Api.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcCodeFirst.Api.GrpcServices
{
    public class ConferenceServiceContractFirst : Interfaces.ConferenceService.ConferenceServiceBase
    {
        private readonly ConferencesDbContext _conferencesDbContext;
        private readonly IMapper _mapper;

        public ConferenceServiceContractFirst(ConferencesDbContext conferencesDbContext, IMapper mapper)
        {
            _conferencesDbContext = conferencesDbContext;
            _mapper = mapper;
        }

        public override async Task<ListConferencesResponse> ListConferences(ListConferencesRequest request, Grpc.Core.ServerCallContext context)
        {
            var conferences = await _conferencesDbContext.Conferences.ToListAsync();
            var confs = _mapper.Map<IEnumerable<ConferenceOverview>>(conferences);

            var response = new ListConferencesResponse();
            response.Conferences.AddRange(confs);

            return response;
        }
    }
}

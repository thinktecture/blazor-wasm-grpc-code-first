using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Conference;
using ConfTool.Server.Model;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace ConfTool.Server.GrpcServices
{
    public class ConferencesServiceContractFirst : Conferences.ConferencesBase
    {
        private readonly ConferencesDbContext _conferencesDbContext;
        private readonly IMapper _mapper;

        public ConferencesServiceContractFirst(ConferencesDbContext conferencesDbContext, IMapper mapper)
        {
            _conferencesDbContext = conferencesDbContext;
            _mapper = mapper;
        }

        public override async Task<ListConferencesResponse> ListConferences(ListConferencesRequest request, ServerCallContext context)
        {
            var conferences = await _conferencesDbContext.Conferences.ToListAsync();
            var confs = _mapper.Map<IEnumerable<ConferenceOverview>>(conferences);

            var response = new ListConferencesResponse();
            response.Conferences.AddRange(confs);

            return response;
        }
    }
}

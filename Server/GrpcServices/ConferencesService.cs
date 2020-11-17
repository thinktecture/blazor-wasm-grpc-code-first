﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlazorWasmGrpcCodeFirst.Server.Model;
using BlazorWasmGrpcCodeFirst.Shared.Contracts;
using BlazorWasmGrpcCodeFirst.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmGrpcCodeFirst.Server.GrpcServices
{
    public class ConferencesService : IConferencesService
    {
        private readonly ConferencesDbContext _conferencesDbContext;
        private readonly IMapper _mapper;

        public ConferencesService(ConferencesDbContext conferencesDbContext, IMapper mapper)
        {
            _conferencesDbContext = conferencesDbContext;
            _mapper = mapper;
        }

        public async Task<ConferenceDetails> AddNewConferenceAsync(ConferenceDetails conference)
        {
            var conf = _mapper.Map<Model.Conference>(conference);
            _conferencesDbContext.Conferences.Add(conf);
            await _conferencesDbContext.SaveChangesAsync();

            return _mapper.Map<Shared.DTO.ConferenceDetails>(conf);
        }

        public async Task<ConferenceDetails> GetConferenceDetailsAsync(ConferenceDetailsRequest request)
        {
            var conferenceDetails = await _conferencesDbContext.Conferences.FindAsync(request.ID);

            if (conferenceDetails == null)
            {
                return null;
            }

            return _mapper.Map<Shared.DTO.ConferenceDetails>(conferenceDetails);
        }

        public async Task<IEnumerable<ConferenceOverview>> ListConferencesAsync()
        {
            var conferences = await _conferencesDbContext.Conferences.ToListAsync();
            var confs = _mapper.Map<IEnumerable<Shared.DTO.ConferenceOverview>>(conferences);

            return confs;
        }
    }
}

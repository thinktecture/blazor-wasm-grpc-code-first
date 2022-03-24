using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GrpcCodeFirst.Shared.DTO;
using GrpcCodeFirst.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GrpcCodeFirst.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ConferencesController : ControllerBase
    {
        private readonly ConferencesDbContext _conferencesDbContext;
        private readonly IMapper _mapper;

        public ConferencesController(ConferencesDbContext conferencesDbContext,
            IMapper mapper)
        {
            _conferencesDbContext = conferencesDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ConferenceOverview>> Get()
        {
            var conferences = await _conferencesDbContext.Conferences.ToListAsync();

            return _mapper.Map<IEnumerable<ConferenceOverview>>(conferences);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConferenceDetails>> Get(string id)
        {
            var conferenceDetails = await _conferencesDbContext.Conferences.FindAsync(Guid.Parse(id));

            if (conferenceDetails == null)
            {
                return NotFound();
            }

            return _mapper.Map<ConferenceDetails>(conferenceDetails);
        }

        [HttpPost]
        public async Task<ActionResult<ConferenceDetails>> PostConference(ConferenceDetails conference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var conf = _mapper.Map<Model.Conference>(conference);
            _conferencesDbContext.Conferences.Add(conf);

            await _conferencesDbContext.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = conference.Id }, _mapper.Map<ConferenceDetails>(conf));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GrpcCodeFirst.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GrpcCodeFirst.Api.Controllers
{
    [Authorize("api")]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ConferencesController : ControllerBase
    {
        private readonly ILogger<ConferencesController> _logger;
        private readonly ConferencesDbContext _conferencesDbContext;
        private readonly IMapper _mapper;

        public ConferencesController(ILogger<ConferencesController> logger,
            ConferencesDbContext conferencesDbContext,
            IMapper mapper)
        {
            _logger = logger;
            _conferencesDbContext = conferencesDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Shared.DTO.ConferenceOverview>> Get()
        {
            var conferences = await _conferencesDbContext.Conferences.ToListAsync();

            return _mapper.Map<IEnumerable<Shared.DTO.ConferenceOverview>>(conferences);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shared.DTO.ConferenceDetails>> Get(string id)
        {
            var conferenceDetails = await _conferencesDbContext.Conferences.FindAsync(Guid.Parse(id));

            if (conferenceDetails == null)
            {
                return NotFound();
            }

            return _mapper.Map<Shared.DTO.ConferenceDetails>(conferenceDetails);
        }

        [HttpPost]
        public async Task<ActionResult<Shared.DTO.ConferenceDetails>> PostConference(Shared.DTO.ConferenceDetails conference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var conf = _mapper.Map<Model.Conference>(conference);
            _conferencesDbContext.Conferences.Add(conf);

            await _conferencesDbContext.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = conference.ID }, _mapper.Map<Shared.DTO.ConferenceDetails>(conf));
        }
    }
}

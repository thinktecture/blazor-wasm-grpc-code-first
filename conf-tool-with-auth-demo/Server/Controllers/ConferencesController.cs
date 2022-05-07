using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConfTool.Server.Hubs;
using ConfTool.Server.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ConfTool.Server.Controllers
{
    [Authorize("api")]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ConferencesController : ControllerBase
    {
        private readonly ConferencesDbContext _conferencesDbContext;
        private readonly IMapper _mapper;
        private readonly IHubContext<ConferencesHub> _hubContext;

        public ConferencesController(ConferencesDbContext conferencesDbContext, 
            IMapper mapper,
            IHubContext<ConferencesHub> hubContext)
        {
            _conferencesDbContext = conferencesDbContext;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Shared.DTO.ConferenceOverview>> Get()
        {
            var conferences = await _conferencesDbContext.Conferences.OrderByDescending(c => c.DateCreated).ToListAsync();

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
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var conf = _mapper.Map<Model.Conference>(conference);
            conf.DateCreated = DateTime.UtcNow;

            _conferencesDbContext.Conferences.Add(conf);
            await _conferencesDbContext.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("NewConferenceAdded");

            return CreatedAtAction("Get", new { id = conference.ID }, _mapper.Map<Shared.DTO.ConferenceDetails>(conf));
        }
    }
}

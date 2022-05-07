using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ConfTool.Server.Model;

namespace ConfTool.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StatisticsController : ControllerBase
    {
        private readonly ConferencesDbContext _conferencesDbContext;

        public StatisticsController(ConferencesDbContext conferencesDbContext)
        {
            _conferencesDbContext = conferencesDbContext;
        }

        [HttpGet]
        public async Task<dynamic> Get()
        {
            var conferences = await _conferencesDbContext.Conferences.ToListAsync();
            var result = conferences.GroupBy(a => a.Country).Select(
                conf => new { name = conf.Key, value = conf.Count() });

            return result;
        }
    }
}

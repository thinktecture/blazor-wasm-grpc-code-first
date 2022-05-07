using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ConfTool.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var countries = new List<string>(){
                "Germany",
                "Austria",
                "Switzerland",
                "Belgium",
                "Netherlands",
                "USA",
                "England"
            };

            return countries;
        }
    }
}

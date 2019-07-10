using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TheApiOfDota.Data.Models;
using TheApiOfDota.Services;

namespace TheApiOfDota.Controllers
{
    public class MatchesController : ApiController
    {
        private readonly SeedService seedService;

        public MatchesController(SeedService seedService)
        {
            this.seedService = seedService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Matches>> Get()
        {
            var data = seedService.SeedMatches();

            // testing
            StaticClass.List.Add(2);

            return data.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<MatchDetails> GetMatchDetails(long id)
        {
            var data = seedService.SeedMatchDetails(id);

            return data;
        }
    }
}
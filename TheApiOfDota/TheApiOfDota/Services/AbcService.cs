namespace TheApiOfDota.Services
{
    using System.Collections.Generic;
    using TheApiOfDota.Data.Models;

    public class AbcService
    {

        public AbcService()
        {
            this.Matches = new List<Matches>();
            this.MatchesDetails = new MatchDetails();
        }

        public List<Matches> Matches { get; set; }

        public MatchDetails MatchesDetails { get; set; }

    }
}

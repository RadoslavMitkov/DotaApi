namespace TheApiOfDota.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using TheApiOfDota.Common;
    using TheApiOfDota.Data;
    using TheApiOfDota.Data.Models;

    public class SeedService
    {
        private readonly AbcService service;
        private readonly Random rand;

        public SeedService(AbcService service)
        {
            this.rand = new Random();
            this.service = service;
        }

        public IEnumerable<Matches> SeedMatches()
        {
            for (var i = 0; i < 20; i++)
            {
                var rScore = this.rand.Next(50);
                var dScore = this.rand.Next(50);

                service.Matches.Add(new Matches
                {
                    Id = rand.Next(100000, 999999),
                    GameMode = rand.Next(999999),
                    Result = rScore > dScore,
                    RadiantScore = rScore,
                    DireScore = dScore,
                    Duration = rand.Next(12600),
                });
            }

            return service.Matches;
        }


        public MatchDetails SeedMatchDetails(long id)
        {
            var currentMatch = service.Matches.First(x => x.Id == id);

            service.MatchesDetails = new MatchDetails
            {
                Id = id,
                Duration = currentMatch.Duration,
                RadiantScore = currentMatch.RadiantScore,
                DireScore = currentMatch.DireScore,
                Winner = currentMatch.Result,
                Players = this.GetPlayers(id, currentMatch.RadiantScore, currentMatch.DireScore)
            };

            return service.MatchesDetails;
        }


        public IEnumerable<TeamPlayerDetails> GetPlayers(long id, int radiantScore, int direScore)
        {
            var players = new List<TeamPlayerDetails>();
            var listOfNames = new List<string>();
            var names = string.Empty;
            var hero = (HeroesEnum)(rand.Next(0, Enum.GetNames(typeof(HeroesEnum)).Length));

            var radiantNums = Util.FindNums(radiantScore);
            var direNums = Util.FindNums(direScore);

            var radiantDeathNums = Util.FindNums(radiantScore);
            var direDeathNums = Util.FindNums(direScore);

            using (var web = new WebClient())
            {
                names = web.DownloadString("https://raw.githubusercontent.com/dominictarr/random-name/master/first-names.txt");
            }

            listOfNames.AddRange(names.Split("\r\n"));

            var playerName = listOfNames[rand.Next(0, listOfNames.Count - 1)];

            for (int i = 0; i < 10; i++)
            {
                players.Add(new TeamPlayerDetails
                {
                    Id = id,
                    PlayerId = rand.Next(0, 1500),
                    PlayerName = playerName,
                    IsRadiant = i < 5,
                    Kills = i < 5 ? radiantNums[i] : direNums[i - 5],
                    Assists = rand.Next(40),
                    Deaths = i < 5 ? direDeathNums[i] : radiantDeathNums[i - 5],
                    Hero = hero.ToString(),
                    LastHits = rand.Next(17),
                    Denies = rand.Next(40),
                    Item0 = rand.Next(8),
                    Item1 = rand.Next(8),
                    Item2 = rand.Next(8),
                    Item3 = rand.Next(8),
                    Item4 = rand.Next(8),
                    Item5 = rand.Next(8),
                    ExperiencePerMin = rand.Next(40),
                    GoldPerMin = rand.Next(100, 1000),
                    HeroDamage = rand.Next(10000, 80000),
                    Healing = rand.Next(8),
                });

                while (hero.ToString() == players[i].Hero)
                {
                    hero = (HeroesEnum)rand.Next(0, Enum.GetNames(typeof(HeroesEnum)).Length);
                }

                while (playerName == players[i].PlayerName)
                {
                    playerName = listOfNames[rand.Next(0, listOfNames.Count - 1)];
                }
            }

            return players;
        }
    }
}

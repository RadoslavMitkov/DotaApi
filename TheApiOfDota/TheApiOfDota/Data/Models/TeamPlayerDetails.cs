namespace TheApiOfDota.Data.Models
{
    using System.Collections.Generic;

    public class TeamPlayerDetails
    {
        public long Id { get; set; }

        public string Hero { get; set; }

        public long? PlayerId { get; set; }

        public string PlayerName { get; set; }

        public bool IsRadiant { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public int Assists { get; set; }

        public int LastHits { get; set; }

        public int Denies { get; set; }

        public int GoldPerMin { get; set; }

        public int ExperiencePerMin { get; set; }

        public int HeroDamage { get; set; }

        public int Healing { get; set; }

        public int Item0 { get; set; }

        public int Item1 { get; set; }

        public int Item2 { get; set; }

        public int Item3 { get; set; }

        public int Item4 { get; set; }

        public int Item5 { get; set; }

        public IEnumerable<int> Items => new[] { Item0, Item1, Item2, Item3, Item4, Item5 };
    }
}

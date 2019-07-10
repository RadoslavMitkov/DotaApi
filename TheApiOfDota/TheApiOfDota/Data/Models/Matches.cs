namespace TheApiOfDota.Data.Models
{
    public class Matches
    {
        public long Id { get; set; }

        public int GameMode { get; set; }

        public bool Result { get; set; }

        public int RadiantScore { get; set; }

        public int DireScore { get; set; }

        public int Duration { get; set; }
    }
}

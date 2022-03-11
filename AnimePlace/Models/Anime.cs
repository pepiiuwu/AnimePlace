namespace AnimePlace.Data
{
 

    public class Anime
    {
        
        public Anime()
        {
            this.Characters = new HashSet<Character>();
            this.Genres = new HashSet<Genre>();
            this.Studios = new HashSet<Studio>();
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Sypnosis { get; set; }

        public double Score { get; set; }

        public int Favorites { get; set; }

        public int? Episodes { get; set; }

        public string Type { get; set; }

        public ICollection<Studio> Studios { get; set; }

        public ICollection<Character> Characters { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}

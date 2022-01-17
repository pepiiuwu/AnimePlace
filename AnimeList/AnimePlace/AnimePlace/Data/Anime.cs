namespace AnimePlace.Data
{
    public class Anime
    {
        private readonly ICollection<Anime> _animes;
        public Anime()
        {
            this.Characters = new HashSet<Character>();
            _animes = new HashSet<Anime>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Sypnosis { get; set; }

        public int? Episodes { get; set; }

        public string Type { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}

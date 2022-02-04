namespace AnimePlace.Data
{
    public class Studio
    {

        public Studio()
        {
            this.Animes = new HashSet<Anime>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Anime> Animes { get; set; }
    }
}
namespace AnimePlace.Data
{
    public class Character
    {

        public Character()
        {
            this.Animes = new HashSet<Anime>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public ICollection<Anime> Animes { get; set; }
    }
}

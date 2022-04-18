namespace AnimePlace.Data
{
    public class Character
    {
        public Character()
        {
            this.Animes = new HashSet<Anime>();
        }
        
        public int CharacterId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Anime> Animes { get; set; }
    }
}

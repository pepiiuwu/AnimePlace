using System;
using System.Collections.Generic;

using AnimeList.Data.Common.Models;

public class Anime : BaseDeletableModel<int>
    {
        public Anime()
        {
            this.Characters = new HashSet<Character>();
            this.Genres = new HashSet<Genre>();
            this.Studios = new HashSet<Studio>();
        }

        public string Name { get; set; }

        public string Sypnosis { get; set; }

        public int Episodes { get; set; }

        public string Type { get; set; }

        public DateTime? Aired { get; set; }

        public double Score { get; set; }

        public int Favorites { get; set; }

        public Image Image { get; set; }

        public virtual ICollection<Character> Characters { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Studio> Studios { get; set; }
}

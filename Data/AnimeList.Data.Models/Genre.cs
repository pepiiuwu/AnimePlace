using System.Collections.Generic;

using AnimeList.Data.Common.Models;

public class Genre : BaseDeletableModel<int>
{
    public Genre()
    {
        this.Animes = new HashSet<Anime>();
    }

    public string Name { get; set; }

    public virtual ICollection<Anime> Animes { get; set; }
}

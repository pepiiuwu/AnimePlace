using System.Collections.Generic;

using AnimeList.Data.Common.Models;

public class Character : BaseDeletableModel<int>
{
    public Character()
    {
        this.Animes = new HashSet<Anime>();
    }

    public string Name { get; set; }

    public string Details { get; set; }

    public virtual ICollection<Anime> Animes { get; set; }
}

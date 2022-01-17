using System.Collections.Generic;

using AnimeList.Data.Common.Models;

public class Studio : BaseDeletableModel<int>
{
    public Studio()
    {
        this.Animes = new HashSet<Anime>();
    }

    public string Name { get; set; }

    public virtual ICollection<Anime> Animes { get; set; }
}

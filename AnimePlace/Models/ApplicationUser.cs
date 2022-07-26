using AnimePlace.Data;
using Microsoft.AspNetCore.Identity;

namespace AnimePlace.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            this.FavoriteCharacters = new HashSet<Character>();
            this.FavoriteAnimes = new HashSet<Anime>();
        }
        public ICollection<Character> FavoriteCharacters { get; set; }

        public ICollection<Anime> FavoriteAnimes { get; set; }

        //public ICollection<Anime> PlanToWatchList { get; set; }

        //public ICollection<Anime> CompletedList { get; set; }

        //public ICollection<Anime> CurrentlyWatchingList { get; set; }
    }
}

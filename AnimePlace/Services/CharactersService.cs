using AnimePlace.Data;
using AnimePlace.Models;
using AnimePlace.Models.ViewModels;
using AnimePlace.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace AnimePlace.Services
{
    public class CharactersService : ICharactersService
    {
        private readonly ApplicationDbContext dbContext;
        
        public CharactersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            
            
        }

        public async Task AddToFavorites(int id, ApplicationUser user)
        {
            var character = dbContext.Characters.Where(x => x.CharacterId == id).First();
            var userasd = dbContext.ApplicationUsers.Where(x => x.Id == user.Id).First();

            userasd.FavoriteCharacters.Add(character);
            await dbContext.SaveChangesAsync();
            
        }

        public CharacterViewModel GetById(int id)
        {
            var character = dbContext.Characters.Where(x => x.CharacterId == id).Select(x => new CharacterViewModel
            {
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Voice = x.Voice,
                Details = x.Details

            }).FirstOrDefault();
            
            return character;
        }
    }
}

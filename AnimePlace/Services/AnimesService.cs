using AnimePlace.Data;
using AnimePlace.Models.InputModels;
using AnimePlace.Services.Contracts;

namespace AnimePlace.Services
{
    public class AnimesService : IAnimesService
    {
        private readonly ApplicationDbContext dbContext;

        public AnimesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(CreateAnimeInputModel input)
        {
            var anime = new Anime()
            {
                Name = input.Name,
                Sypnosis = input.Sypnosis,
                Type = input.Type,
                Episodes = input.Episodes
            };

            if(!dbContext.Animes.Any(x => x.Name == anime.Name))
            {
                await dbContext.Animes.AddAsync(anime);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}

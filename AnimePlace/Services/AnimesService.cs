using AnimePlace.Data;
using AnimePlace.Models.InputModels;
using AnimePlace.Models.ViewModels;
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
                Type = input.Type.ToString(),
                Episodes = input.Episodes
            };

            if(!dbContext.Animes.Any(x => x.Name == anime.Name))
            {
                await dbContext.Animes.AddAsync(anime);
            }

            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<AnimeListViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            //.Skip((page -1) * itemsPerPage).Take(itemsPerPage);
            var result = dbContext.Animes.OrderByDescending(x => x.Favorites)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new AnimeListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Synopsis = x.Sypnosis,
                    ImageUrl = x.ImageUrl,
                }).ToList();

            return result;
        }

        public int GetCount()
        {
            return dbContext.Animes.Count();
        }
    }
}

using AnimePlace.Models.InputModels;

namespace AnimePlace.Services.Contracts
{
    public interface IAnimesService
    {
        public Task CreateAsync(CreateAnimeInputModel input);
    }
}

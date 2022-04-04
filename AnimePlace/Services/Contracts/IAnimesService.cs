using AnimePlace.Models.InputModels;
using AnimePlace.Models.ViewModels;

namespace AnimePlace.Services.Contracts
{
    public interface IAnimesService
    {
        public Task CreateAsync(CreateAnimeInputModel input);

        public IEnumerable<AnimeListViewModel> GetAll(int page, int itemsPerPage = 10);
    }
}

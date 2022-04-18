using AnimePlace.Data;
using AnimePlace.Models.InputModels;
using AnimePlace.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnimePlace.Services.Contracts
{
    public interface IAnimesService
    {
        public Task CreateAsync(CreateAnimeInputModel input);

        public IEnumerable<AnimeListViewModel> GetAll(int page, int itemsPerPage);

        int GetCount();

        public SingleAnimeViewModel GetById(int id);

        public ICollection<CharacterViewModel> GetAllForAnime(int id);
    }
}

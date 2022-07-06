﻿using AnimePlace.Data;
using AnimePlace.Models.InputModels;
using AnimePlace.Models.ViewModels;
using AnimePlace.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

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
                AlternativeName = input.AlternativeName,
                Sypnosis = input.Sypnosis,
                Type = input.Type.ToString(),
                Episodes = input.Episodes,
                ImageUrl = input.ImageUrl,
            };

            if(!dbContext.Animes.Any(x => x.Name == anime.Name))
            {
                await dbContext.Animes.AddAsync(anime);
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(EditAnimeInputModel input, int id)
        {
            var anime = await dbContext.Animes.FindAsync(id);

            if(anime == null)
            {
                return;
            }

            anime.Name = input.Name;
            anime.AlternativeName = input.AlternativeName;
            anime.Episodes = input.Episodes;
            anime.Sypnosis = input.Sypnosis;

            dbContext.Animes.Update(anime);

            await dbContext.SaveChangesAsync();
        }

        public EditAnimeInputModel GetEdit(int id)
        {
            var anime = dbContext.Animes.Find(id);

            var viewModel = new EditAnimeInputModel()
            {
                Name = anime.Name,
                AlternativeName = anime.AlternativeName,
                Episodes = anime.Episodes,
                ImageUrl = anime.ImageUrl,
                Sypnosis = anime.Sypnosis
            };

            return viewModel;
        }

        public IEnumerable<AnimeListViewModel> GetAll(int page = 2, int itemsPerPage = 30)
        {
            //.Skip((page -1) * itemsPerPage).Take(itemsPerPage);
            var result = dbContext.Animes.ToList().OrderByDescending(x => x.Favorites)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new AnimeListViewModel
                {
                    Id = x.AnimeId,
                    Name = x.Name,
                    Synopsis = x.Sypnosis,
                    ImageUrl = x.ImageUrl,
                });

            return result;
        }

        public SingleAnimeViewModel GetById(int id)
        {
            
            var result = dbContext.Animes.Where(x => x.AnimeId == id).Select(x => new SingleAnimeViewModel
            {
                Id = id,
                Name = x.Name,
                AlternativeName = x.AlternativeName,
                Sypnosis = x.Sypnosis,
                ImageUrl = x.ImageUrl,
                BorderImageUrl = x.BorderImageUrl,
                Score = x.Score,
                Episodes = x.Episodes,
                Type = x.Type,
                Favorites = x.Favorites,


            }).FirstOrDefault();

            return result;
        }

        public int GetCount()
        {
            return dbContext.Animes.Count();
        }

        public ICollection<CharacterViewModel> GetAllForAnime(int id)
        {



            var anime = dbContext.Animes.Where(x => x.AnimeId == id).Select(x => x.Characters).ToList();
            var result = anime.SelectMany(x => x);
            ICollection<CharacterViewModel> collection = new List<CharacterViewModel>();
            foreach (var item in result)
            {
                CharacterViewModel characterViewModel = new CharacterViewModel();
                characterViewModel.Name = item.Name;
                characterViewModel.ImageUrl = item.ImageUrl;
                collection.Add(characterViewModel);
            }

            return collection;
        }

        public async Task Delete(int id)
        {
            var anime = await dbContext.Animes.FindAsync(id);


            dbContext.Remove(anime);

            
            await dbContext.SaveChangesAsync();

        }

        
    }
}

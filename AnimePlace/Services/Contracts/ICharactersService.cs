﻿using AnimePlace.Models;
using AnimePlace.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AnimePlace.Services.Contracts
{
    public interface ICharactersService
    {
        public CharacterViewModel GetById(int id);

        public Task AddToFavorites(int id, ApplicationUser user);
    }
}

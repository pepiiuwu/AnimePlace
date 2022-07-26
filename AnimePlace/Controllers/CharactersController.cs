using AnimePlace.Models;
using AnimePlace.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnimePlace.Controllers
{
    public class CharactersController : Controller
    {

        private readonly ICharactersService charactersService;
        private readonly UserManager<ApplicationUser> userManager;

        public CharactersController(ICharactersService characterService, UserManager<ApplicationUser> userManager)
        {
            this.charactersService = characterService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            if(id  < 1)
            {
                return NotFound();
            }

            var view = charactersService.GetById(id);

            if(view == null)
            {
                return NotFound();
            }

            return View(view);
        }

        [Authorize]
        public async Task<IActionResult> AddToFavorites(int id)
        {
            var currentUser = userManager.GetUserAsync(this.User);

            if (id < 1)
            {
                return NotFound();
            }

            

            await charactersService.AddToFavorites(id, await currentUser);
            return RedirectToAction("/");
        }
    }
}

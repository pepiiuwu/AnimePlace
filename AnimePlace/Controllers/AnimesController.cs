using AnimePlace.Data;
using AnimePlace.Models.InputModels;
using AnimePlace.Models.ViewModels;
using AnimePlace.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AnimePlace.Controllers
{
    public class AnimesController : Controller
    {

        private readonly IAnimesService animesService;

        public AnimesController(IAnimesService animesService)
        {
            this.animesService = animesService;
        }

        public IActionResult Index(int id)
        {
            var viewModel = new AnimesListViewModel
            {
                PageNumber = id,
                Animes = animesService.GetAll(id, 20),
            };
            return View(viewModel);
        }

        public IActionResult AllAnimes(int id = 1)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            const int AnimesPerPage = 30;

            var viewModel = new AnimesListViewModel
            {
                AnimesPerPage = AnimesPerPage,
                PageNumber = id,
                AnimesCount = animesService.GetCount(),
                Animes = animesService.GetAll(id, AnimesPerPage),
            };

            return View(viewModel);

        }

        //Add authorization, so only Admin roles can Add New/Create Animes
        // GET: AnimesController/Create
        public IActionResult Create()
        {
            var viewModel = new CreateAnimeInputModel();
            //viewModel.TypeItems

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAnimeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            await this.animesService.CreateAsync(input);
            //return this.Json(input);
            return this.RedirectToAction("AllAnimes", "Animes");
        }

        // GET: AnimesController/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }

            var viewModel = animesService.GetEdit(id);


            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditAnimeInputModel input, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.animesService.EditAsync(input, id);

            //return this.Json(input);

            return this.RedirectToAction("AllAnimes", "Animes");
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }

            var viewModel = animesService.GetEdit(id);


            if (viewModel == null)
            {
                return NotFound();
            }


            return this.View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await animesService.Delete(id);

            return this.RedirectToAction("AllAnimes", "Animes");

        }

        public IActionResult GetById(int id)
        {
            SingleAnimeViewModel anime = this.animesService.GetById(id);

            if (anime == null)
            {
                return this.NotFound();
            }

            anime.Characters = this.animesService.GetAllForAnime(id);



            return this.View(anime);
        }
    }
}

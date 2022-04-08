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
        public readonly ApplicationDbContext _db;
        private readonly IAnimesService animesService;

        public AnimesController(ApplicationDbContext db, IAnimesService animesService)
        {
            _db = db;
            this.animesService = animesService;
        }
        // GET: AnimesController
        public ActionResult Index(int id)
        {
            var viewModel = new AnimesListViewModel
            {
                PageNumber = id,
                Animes = animesService.GetAll(id, 12),
            };
            return View(viewModel);
        }

        public ActionResult AllAnimes(int id = 1)
        {
            const int AnimesPerPage = 12;

            var viewModel = new AnimesListViewModel
            {
                AnimesPerPage = AnimesPerPage,
                PageNumber = id,
                AnimesCount = animesService.GetCount(),
                Animes = animesService.GetAll(id, AnimesPerPage),
            };
            return View(viewModel);

        }

        // GET: AnimesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //Add authorization, so only Admin roles can Add New/Create Animes
        // GET: AnimesController/Create
        public ActionResult Create()
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
            return this.RedirectToAction("Index");
        }
        

        //POST: AnimesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
            
            
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
            
        //} 

        // GET: AnimesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnimesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnimesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnimesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

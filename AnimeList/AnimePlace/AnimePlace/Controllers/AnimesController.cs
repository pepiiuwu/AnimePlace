using AnimePlace.Data;
using AnimePlace.Models.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AnimePlace.Controllers
{
    public class AnimesController : Controller
    {
        public readonly ApplicationDbContext _db;

        public AnimesController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: AnimesController
        public ActionResult Index()
        {
            return View(_db.Animes.ToList());
        }

        // GET: AnimesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnimesController/Create
        public ActionResult Create()
        {
            var viewModel = new CreateAnimeInputModel();
            //viewModel.TypeItems
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateAnimeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                //input.TypeItems = 
                return this.View();
            }
            return this.Redirect("/");
        }

        // POST: AnimesController/Create
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        } */

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

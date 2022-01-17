namespace AnimeList.Web.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class AnimeController : Controller
    {
        // GET: AnimeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnimeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnimeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimeController/Create
        [HttpPost]
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
        }

        // GET: AnimeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnimeController/Edit/5
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

        // GET: AnimeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnimeController/Delete/5
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

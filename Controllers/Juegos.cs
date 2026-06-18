using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controladores
{
    public class Juegos : Controller
    {
        // GET: Juegos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Juegos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Juegos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Juegos/Create
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

        // GET: Juegos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Juegos/Edit/5
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

        // GET: Juegos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Juegos/Delete/5
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

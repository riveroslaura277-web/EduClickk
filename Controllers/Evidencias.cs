using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class Evidencias : Controller
    {
        // GET: Evidencias
        public ActionResult Index()
        {
            return View();
        }

        // GET: Evidencias/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Evidencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evidencias/Create
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

        // GET: Evidencias/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Evidencias/Edit/5
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

        // GET: Evidencias/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Evidencias/Delete/5
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

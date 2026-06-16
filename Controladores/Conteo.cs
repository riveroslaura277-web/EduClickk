using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controladores
{
    public class Conteo : Controller
    {
        // GET: Conteo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Conteo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Conteo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conteo/Create
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

        // GET: Conteo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Conteo/Edit/5
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

        // GET: Conteo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Conteo/Delete/5
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

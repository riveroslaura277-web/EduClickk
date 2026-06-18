using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controladores
{
    public class Logros : Controller
    {
        // GET: Logros
        public ActionResult Index()
        {
            return View();
        }

        // GET: Logros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Logros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logros/Create
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

        // GET: Logros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Logros/Edit/5
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

        // GET: Logros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Logros/Delete/5
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

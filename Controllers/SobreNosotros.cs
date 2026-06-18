using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controladores
{
    public class SobreNosotros : Controller
    {
        // GET: SobreNosotros
        public ActionResult Index()
        {
            return View();
        }

        // GET: SobreNosotros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SobreNosotros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SobreNosotros/Create
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

        // GET: SobreNosotros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SobreNosotros/Edit/5
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

        // GET: SobreNosotros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SobreNosotros/Delete/5
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

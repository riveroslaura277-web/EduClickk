using EduClick.Data;
using EduClick.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class EvidenciasController : Controller
    {
        private readonly EduClickContext _context;

        public EvidenciasController(EduClickContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Mensaje = TempData["Mensaje"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirArchivo(IFormFile archivo)
        {
            if (archivo != null && archivo.Length > 0)
            {
                string carpeta = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "uploads");

                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                string rutaArchivo = Path.Combine(
                    carpeta,
                    archivo.FileName);

                using (var stream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }

                var entrega = new EntregaTarea
                {
                    NombreArchivo = archivo.FileName,
                    NombreEstudiante = "Sofía",
                    FechaEntrega = DateTime.Now
                };

                _context.EntregasTareas.Add(entrega);
                _context.SaveChanges();

                TempData["Mensaje"] = "✅ Archivo subido correctamente";
            }
            else
            {
                TempData["Mensaje"] = "❌ Debes seleccionar un archivo";
            }

            return RedirectToAction("Index");
        }
    }
}
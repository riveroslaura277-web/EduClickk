using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduClick.Data;
using EduClick.Models;
using System.IO;
using System.Linq;

namespace EduClick.Controllers
{
    public class EvidenciasController : Controller
    {
        private readonly EduClickContext _context;

        public EvidenciasController(EduClickContext context)
        {
            _context = context;
        }

        // Lista evidencias subidas
        public IActionResult Index()
        {
            var evidencias = _context.Evidencias
                .Include(e => e.DetalleEstudiante)
                .Where(e => e.IdDetalle == 27) // ejemplo: filtra estudiante detalle 27
                .ToList();

            // enviar lista de estudiantes a la vista
            ViewBag.Estudiantes = _context.DetalleEstudiantes.ToList();

            return View(evidencias);
        }

        // Acción para subir archivo
        [HttpPost]
        public IActionResult SubirArchivo(IFormFile archivo)
        {
            int idDetalle = 2; // ejemplo fijo

            var detalle = _context.DetalleEstudiantes.Find(idDetalle);
            if (detalle == null)
            {
                TempData["Mensaje"] = "⚠️ El detalle de estudiante no existe en la base de datos.";
                return RedirectToAction("Index");
            }

            if (archivo != null)
            {
                var nombreArchivo = Path.GetFileName(archivo.FileName);
                var ruta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", nombreArchivo);

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    archivo.CopyTo(stream);
                }

                var evidencia = new Evidencia
                {
                    FechaEntrega = DateTime.Now,
                    Estado = "Pendiente",
                    IdDetalle = idDetalle,
                    NombreArchivo = nombreArchivo
                };

                _context.Evidencias.Add(evidencia);
                _context.SaveChanges();
                TempData["Mensaje"] = "✅ Archivo subido correctamente";
            }

            return RedirectToAction("Index");
        }

        // Vista para calificar evidencia
        public IActionResult Calificar(int id)
        {
            var evidencia = _context.Evidencias
                .Include(e => e.DetalleEstudiante)
                .FirstOrDefault(e => e.Id == id);

            if (evidencia == null)
            {
                return NotFound();
            }

            return View(evidencia);
        }

        // Guardar calificación con reglas de logros
        [HttpPost]
        public IActionResult GuardarCalificacion(int id, decimal nota, string? observacion)
        {
            var evidencia = _context.Evidencias
                .Include(e => e.DetalleEstudiante)
                .FirstOrDefault(e => e.Id == id);

            if (evidencia != null)
            {
                evidencia.Nota = nota;
                evidencia.Observacion = observacion;
                evidencia.Estado = "Calificado";
                _context.SaveChanges();

                // Regla: Trabajo destacado
                if (nota == 5.0m)
                {
                    CrearLogro("Trabajo destacado", "Obtuvo la nota máxima en una evidencia", "fa-medal", evidencia.IdDetalle);
                }

                // Regla: Constancia (3 evidencias aprobadas)
                var aprobadas = _context.Evidencias
                    .Count(e => e.IdDetalle == evidencia.IdDetalle && e.Nota >= 3.0m);

                if (aprobadas >= 3)
                {
                    CrearLogro("Constancia", "Ha entregado varias evidencias aprobadas seguidas", "fa-trophy", evidencia.IdDetalle);
                }
            }

            return RedirectToAction("Index");
        }

        // Método auxiliar para crear logros
        private void CrearLogro(string nombre, string descripcion, string icono, int idDetalle)
        {
            // Aquí defines cómo guardar el logro en tu base de datos
            // Ejemplo:
            /*
            var logro = new Logro
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Icono = icono,
                IdDetalle = idDetalle,
                Fecha = DateTime.Now
            };
            _context.Logros.Add(logro);
            _context.SaveChanges();
            */
        }
    }
}

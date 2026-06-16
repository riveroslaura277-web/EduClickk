using Microsoft.AspNetCore.Mvc;
using EduClick.Models;
using System.Collections.Generic;
using System.Linq;

namespace EduClick.Controllers
{
    public class DocenteController : Controller
    {
        private static List<Nota> notas = new List<Nota>
        {
            new Nota { Id = 1, Nombre = "María López", Asistencias = 20, Faltas = 2 },
            new Nota { Id = 2, Nombre = "Julian Paredes", Asistencias = 15, Faltas = 4 },
            new Nota { Id = 3, Nombre = "Lorena Cristancho", Asistencias = 25, Faltas = 0 }
        };

        public IActionResult Index()
        {
            return View("Docente", notas);
        }

        [HttpPost]
        public IActionResult Editar(Nota nota)
        {
            var existente = notas.FirstOrDefault(n => n.Id == nota.Id);
            if (existente != null)
            {
                existente.Nombre = nota.Nombre;
                existente.Asistencias = nota.Asistencias;
                existente.Faltas = nota.Faltas;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var nota = notas.FirstOrDefault(n => n.Id == id);
            if (nota != null)
            {
                notas.Remove(nota);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Nota nota)
        {
            nota.Id = notas.Count > 0 ? notas.Max(n => n.Id) + 1 : 1;
            notas.Add(nota);
            return RedirectToAction("Index");
        }
    }
}

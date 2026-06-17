using EduClick.Models;
using Microsoft.AspNetCore.Mvc;
using EduClick.Data;
using EduClick.Models;

public class EstudiantesController : Controller
{
    private readonly EduClickContext _context;
    public EstudiantesController(EduClickContext context) { _context = context; }

    // Lista de estudiantes
    public IActionResult Index()
    {
        var estudiantes = _context.Estudiantes.ToList();
        return View(estudiantes);
    }

    // Formulario de registro
    [HttpGet]
    public IActionResult Registrar() => View();

    [HttpPost]
    [HttpPost]
    public IActionResult Registrar(Estudiantes estudiante)
    {
        if (ModelState.IsValid)
        {
            _context.Estudiantes.Add(estudiante);
            _context.SaveChanges();
            TempData["Mensaje"] = "Estudiante registrado correctamente ✅";
            return RedirectToAction("Index");
        }
        return View(estudiante);
    }
}


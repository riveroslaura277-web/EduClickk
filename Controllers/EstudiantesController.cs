using EduClick.Models;
using Microsoft.AspNetCore.Mvc;
using EduClick.Data;


public class EstudiantesController : Controller
{

    private readonly EduClickContext _context;
    public EstudiantesController(EduClickContext context) { _context = context; }


}

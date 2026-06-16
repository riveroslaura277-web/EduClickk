using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduClick.Controllers
{
    public class DshboardINICIOController : Controller
    {
        public IActionResult Index()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            return View();
        }
    }
}

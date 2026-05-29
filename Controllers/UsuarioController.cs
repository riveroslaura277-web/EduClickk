using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Inicio()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleCallback", "Account")
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
    }
}

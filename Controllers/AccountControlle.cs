using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult GoogleLogin()
    {
        // URL a la que Google redirige después del login
        var redirectUrl = Url.Action("GoogleResponse", "Account");
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };

        // Dispara el challenge con Google
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync();
        var claims = result.Principal.Identities.FirstOrDefault()?.Claims
            .Select(c => new { c.Type, c.Value });

        var email = claims.FirstOrDefault(c => c.Type.Contains("email"))?.Value;
        var nombre = claims.FirstOrDefault(c => c.Type.Contains("name"))?.Value;

        ViewBag.Email = email;
        ViewBag.Nombre = nombre;

        return View();
    }
}

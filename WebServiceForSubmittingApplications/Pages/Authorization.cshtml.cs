using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using API.Controllers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace WebApplications.Pages
{
    public class AuthorizationModel : PageModel
    {
        public async Task<IActionResult> OnPost(string? returnUrl)
        {
            var form = HttpContext.Request.Form;
            if (!form.ContainsKey("email") || !form.ContainsKey("password"))
                BadRequest("Email и/или пароль не установлены");
            string? email = form["email"];
            string? password = form["password"];
            ApplicationController ac = new ApplicationController();
            ClaimsPrincipal principal = ac.GetAuthorizeUser(email, password);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Redirect("/Index");
        }
    }
}

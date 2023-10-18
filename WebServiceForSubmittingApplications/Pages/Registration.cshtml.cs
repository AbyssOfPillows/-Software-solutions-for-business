using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using API.Models;

namespace WebApplications.Pages
{
    public class RegistrationModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(string? returnUrl)
        {
            var form = HttpContext.Request.Form;
            // ���� email �/��� ������ �� �����������, �������� ��������� ��� ������ 400
            if (!form.ContainsKey("email") || !form.ContainsKey("password"))
                return BadRequest("Email �/��� ������ �� �����������");
            string? email = form["email"];
            string? password = form["password"];
            CompanyContext db = new CompanyContext();
            Application user = new Application();
            user.EMail = email;
            user.Password = password;
            db.Applications.Add(user);
            db.SaveChanges();
            return Redirect(returnUrl ?? "/OrderApplication");
        }
    }
}

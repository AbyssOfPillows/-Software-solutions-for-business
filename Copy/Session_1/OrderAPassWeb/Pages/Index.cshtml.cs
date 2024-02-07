using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;
using Models;
using System.Text.Json;
namespace OrderAPassWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost(string? returnUrl)
        {
            var form = HttpContext.Request.Form;
            if ((form["password"].ToString() == "") || (form["email"].ToString() == ""))
            {
                return BadRequest("Нет почты или пароля");
            }
            string strPassword = form["password"].ToString();
            byte[] bytes = Encoding.UTF8.GetBytes(strPassword);
            byte[] byteMD5 = MD5.Create().ComputeHash(bytes);
            string passwordMD5 = "";
            foreach (byte b in bytes)
            {
                passwordMD5 = passwordMD5 + (b.ToString());
            }
            string strMail = form["email"].ToString();
            return Redirect($"/Choice?password={passwordMD5}&email={strMail}");

        }
    }
}
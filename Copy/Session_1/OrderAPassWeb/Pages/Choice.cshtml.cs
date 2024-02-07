using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrderAPassWeb.Pages
{
    public class PostIndividualApplicationWindowModel : PageModel
    {
        public string? password;
        public string? email;
        public void OnGet()
        {
            password = Request.Query["password"]!;
            email = Request.Query["email"]!;
        }
        public void OnPost()
        {
            
        }
    }
}

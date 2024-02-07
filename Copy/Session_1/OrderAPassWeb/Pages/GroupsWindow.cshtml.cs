using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Models;
using Microsoft.Office.Interop.Excel;

namespace OrderAPassWeb.Pages
{
    public class GroupsWindowModel : PageModel
    {
        HttpClient client = new HttpClient();
        public void OnGet()
        {

         
        }
        public  IActionResult OnPost(string? returnUrl)
        {
             return Redirect("/");
        }
    }
}

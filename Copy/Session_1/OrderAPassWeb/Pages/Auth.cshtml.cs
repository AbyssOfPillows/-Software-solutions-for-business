using Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrderAPassWeb.Pages
{
    public class AuthModel : PageModel
    {
        public async Task<IActionResult> OnPost()
        {
            var form = Request.Form;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            var response = await client.GetAsync($"/auth/login={form["login"]}&password={form["password"]}");
            var status = response.StatusCode;
            if(status == System.Net.HttpStatusCode.OK)
            {
                return Redirect("/Choice");
            
            }
            else return BadRequest(status);
        }
    }
}

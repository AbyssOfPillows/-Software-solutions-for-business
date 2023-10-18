using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using API.Controllers;
using static API.Controllers.ApplicationController;

namespace WebApplications.Pages
{
    public class ExamplesOfApplicationsModel : PageModel
    {
        public List<UserApp> list = new();
        public void OnGet()
        {
            ApplicationController ac = new ApplicationController();
            list = ac.GetExamples();
        }
    }
}

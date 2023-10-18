using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using API.Controllers;
using API.Models;

namespace WebApplications.Pages
{
    public class IndividualVisitModel : PageModel
    {
        public List<Departament> departamentList = new List<Departament>();
        public async void OnGet()
        {
            CompanyContext db = new CompanyContext();
            departamentList = db.Departaments.ToList();
        }
        public async void OnPost()
        {
            IFormCollection form = HttpContext.Request.Form;
            ApplicationController applicationController = new ApplicationController();
            await applicationController.PostIndividualApplication(form);
        }
        
    }
}

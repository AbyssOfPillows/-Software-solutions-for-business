using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace OrderAPassWeb.Pages
{
    public class IndividualWindowModel : PageModel
    {
        List<Departament>? departments;
        List<Employee>? employees;
        public void OnGet()
        {
            
        }

        private static string SerializeObject(IEnumerable<KeyValuePair<string, StringValues>> model)
        {
            if (!model.Any())
                return string.Empty;

            var dic = new Dictionary<string, string>();
            foreach (var kv in model)
                dic.Add(kv.Key, kv.Value);

            return JsonSerializer.Serialize(dic);
        }

        public async Task<IActionResult> OnPost(string? returnUrl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080");
            string password = Request.Query["password"]!;
            string email = Request.Query["email"]!;
            var form = HttpContext.Request.Form;
            //VisitorsController visitorsController = new VisitorsController();
            Visitor visitor = new Visitor();
            visitor.Surname = form["Surname"]!;
            visitor.Name = form["Name"]!;
            visitor.Patronymic = form["Patronymic"]!;
            visitor.NumberPhone = form["NumberPhone"]!;
            visitor.EMail = form["EMail"]!;
            visitor.Password = password;
            visitor.PasportSeria = Convert.ToInt32(form["Seria"]);
            visitor.PasportNumber = Convert.ToInt32(form["Number"]);
            visitor.Login = email;
            string date = form["DateOfBirth"].ToString();
            var dateTime = DateOnly.ParseExact(date, "yyyy-dd-mmmm", null);
            visitor.DateOfBirth = dateTime.ToString();
            visitor.Login = form["EMail"]!;
            var response = await client.PostAsJsonAsync("/visitors", visitor);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response = await client.PostAsJsonAsync("/Groups", visitor);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Group group = response.Content.ReadFromJsonAsync<Group>().Result!;
                    response = await client.GetAsync($"/employees/Departament={form["subdibision"]}&Fio={form["Fio"]}");
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Employee emp = response.Content.ReadFromJsonAsync<Employee>().Result!;
                        Application application = new Application();
                        application.Purpose = form["Purpose"]!;
                        application.DesiredStartDate = DateTime.Parse(form["start_date"]!);
                        application.DesiredEndDate = DateTime.Parse(form["end_date"]!);
                        application.Employee = emp;
                        application.Group = group;
                        response = await client.PostAsJsonAsync($"/applications", application);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return Redirect(returnUrl ?? "/Choice");
                        }

                    }
                }
                
            }
            return BadRequest("Произошла ошибка");
            
        }

    }
}

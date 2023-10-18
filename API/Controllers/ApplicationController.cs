using API.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System.Text.Json;

namespace API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        public class UserApp
        {
            public string? Type = "";
            public string? Departament = "None";
            public string? Date = "None";
            public bool? Status = false;
            public string? Reason = "";

        }
        [HttpGet]
        [Route("[controller]/GetAllApplication")]
        public List<Application> GetAllApplication()
        {
            CompanyContext db = new CompanyContext();
            List<Application> applications = db.Applications.ToList();
            if (applications == null)
            {
                NotFound();
            }
            return applications;
        }
        [HttpPut]
        [Route("[controller]/PutApprovedUser")]
        public IActionResult PutApprovedUser(int id, bool approved, string reason)
        {
            CompanyContext db = new CompanyContext();
            List<Application> applications = db.Applications.ToList();
            if (applications == null)
            {
                return NotFound();
            }
            Application application = applications[id];
            application.Approved = approved;
            application.Reason = reason;
            db.SaveChanges();
            return Ok(application);
        }
        [HttpPost]
        [Route("[controller]/PostIndividualApplication")]
        public async Task<IActionResult> PostIndividualApplication(IFormCollection form)
        {
            
            CompanyContext db = new CompanyContext();
            if (!form.ContainsKey("mail") || !form.ContainsKey("surname") || !form.ContainsKey("name") || !form.ContainsKey("DataOfBirth") || !form.ContainsKey("PasportsSeria") || !form.ContainsKey("PasportsNum") || !form.ContainsKey("note") || !form.ContainsKey("Subdivision") || !form.ContainsKey("FIO") || !form.ContainsKey("Company") || !form.ContainsKey("surname") || !form.ContainsKey("PassportScan")) 
                return BadRequest("Email и/или пароль не установлены");
            DateTime now = DateTime.Now;
            int yearOfNow = now.Year;
            string dateOfBirthString = form["DataOfBirth"].ToString();
            DateTime dateOfBirth = DateTime.Parse(dateOfBirthString);
            int yearOfBirth = dateOfBirth.Year;
            int year = yearOfNow - yearOfBirth;
            if (year < 16)
            {
                return BadRequest();
            }
            if (year == 16)
            {
                int monthOfNow = now.Month;
                int MonthOfBirth = dateOfBirth.Month;
                int month = monthOfNow - MonthOfBirth;
                if(month < 0) return BadRequest();
                if(month == 0)
                {
                    int DayOfNow = now.Day;
                    int DayOfBirth = dateOfBirth.Day;
                    int Day = DayOfNow - DayOfBirth;
                    if(Day < 0) return BadRequest();
                }
            }
            Application newApplication = new Application();
            StringBuilder Fio = new StringBuilder();
            Fio.Append($"{form["surname"]} {form["name"]} {form["patronymic"]}");
            newApplication.Fio = Fio.ToString();
            StringBuilder pasport = new StringBuilder();
            pasport.Append($"{form["PasportsSeria"]} {form["PasportsNum"]}");
            newApplication.PasportDetails = pasport.ToString();
            newApplication.PhoneNumber = form["phone"];
            newApplication.EMail = pasport.ToString();
            newApplication.TypeApplication = "Individual";
            newApplication.Organization = form["Company"];
            newApplication.DateOfBirth = form["DataOfBirth"];
            newApplication.Note = form["note"];
            byte[] photo = System.IO.File.ReadAllBytes(form["visiorPhoto"]);
            newApplication.Photo = photo;
            byte[] passScan = System.IO.File.ReadAllBytes(form["PassportScan"]);
            newApplication.PassportScan = passScan;
            Group newGroup = new Group();
            Appointment newAppointment = new Appointment();
            int EmpCode = db.Employes.First(e => e.Fio == form["FIO"]).EmployeeCode;
            newAppointment.EmployeId = EmpCode;
            db.Appointments.Add(newAppointment);
            await db.SaveChangesAsync();
            newGroup.Appointment = db.Appointments.OrderBy(a => a.Id).Last().Id;
            db.Groups.Add(newGroup);
            await db.SaveChangesAsync();
            newApplication.GroupId = db.Groups.OrderBy(a => a.Id).Last().Id;
            db.Applications.Add(newApplication);
            await db.SaveChangesAsync();
            return Ok(newApplication);
        }
        [HttpPost]
        [Route("[controller]/PostGroupApplication")]
        public async Task<IActionResult> PostGroupApplication(IFormCollection form)
        {
            CompanyContext db = new CompanyContext();
            if (!form.ContainsKey("mail") || !form.ContainsKey("surname") || !form.ContainsKey("name") || !form.ContainsKey("DataOfBirth") || !form.ContainsKey("PasportsSeria") || !form.ContainsKey("PasportsNum") || !form.ContainsKey("note") || !form.ContainsKey("Subdivision") || !form.ContainsKey("FIO") || !form.ContainsKey("Company") || !form.ContainsKey("surname"))
                return BadRequest("Email и/или пароль не установлены");
            DateTime now = DateTime.Now;
            int yearOfNow = now.Year;
            string dateOfBirthString = form["DataOfBirth"].ToString();
            DateTime dateOfBirth = DateTime.Parse(dateOfBirthString);
            int yearOfBirth = dateOfBirth.Year;
            int year = yearOfNow - yearOfBirth;
            if (year < 16)
            {
                return BadRequest();
            }
            if (year == 16)
            {
                int monthOfNow = now.Month;
                int MonthOfBirth = dateOfBirth.Month;
                int month = monthOfNow - MonthOfBirth;
                if (month < 0) return BadRequest();
                if (month == 0)
                {
                    int DayOfNow = now.Day;
                    int DayOfBirth = dateOfBirth.Day;
                    int Day = DayOfNow - DayOfBirth;
                    if (Day < 0) return BadRequest();
                }
            }
            Application newApplication = new Application();
            StringBuilder Fio = new StringBuilder();
            Fio.Append($"{form["surname"]} {form["name"]} {form["patronymic"]}");
            newApplication.Fio = Fio.ToString();
            StringBuilder pasport = new StringBuilder();
            pasport.Append($"{form["PasportsSeria"]} {form["PasportsNum"]}");
            newApplication.PasportDetails = pasport.ToString();
            newApplication.PhoneNumber = form["phone"];
            newApplication.EMail = pasport.ToString();
            newApplication.TypeApplication = "Individual";
            newApplication.Organization = form["Company"];
            newApplication.DateOfBirth = form["DataOfBirth"];
            newApplication.Note = form["note"];
            Group newGroup = new Group();
            Appointment newAppointment = new Appointment();
            int EmpCode = db.Employes.First(e => e.Fio == form["FIO"]).EmployeeCode;
            newAppointment.EmployeId = EmpCode;
            db.Appointments.Add(newAppointment);
            await db.SaveChangesAsync();
            newGroup.Appointment = db.Appointments.OrderBy(a => a.Id).Last().Id;
            db.Groups.Add(newGroup);
            await db.SaveChangesAsync();
            newApplication.GroupId = db.Groups.OrderBy(a => a.Id).Last().Id;
            db.Applications.Add(newApplication);
            await db.SaveChangesAsync();
            return Ok(newApplication);
        }

        [HttpGet]
        [Route("[controller]/GetEmployeeСodeСomparison")]
        public string GetEmployeeСodeСomparison(string empCode, int DepartamentId)
        {
            CompanyContext db = new CompanyContext();
            int founded = Convert.ToInt32(empCode);
            Employe emp = db.Employes.First(e => e.EmployeeCode == founded);
            if (emp != null){
               
                if(emp.Departament == DepartamentId) return JsonSerializer.Serialize(db.Applications.ToArray());
            }
            return null;
        }
        [HttpGet]
        [Route("[controller]/Authorize")]
        public ClaimsPrincipal GetAuthorizeUser(string login, string password)
        {
            CompanyContext db = new CompanyContext();
            List<Application> users = db.Applications.ToList();
            // находим пользователя 
            Application? user = users.FirstOrDefault(p => p.EMail == login && p.Password == password);
            // если пользователь не найден, отправляем статусный код 401
            if (user is null) Unauthorized();
            if (user.EMail != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.EMail) };
                // создаем объект ClaimsIdentity
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(claimsIdentity);
                // установка аутентификационных куки
                return principal;
            }
            BadRequest("Нет с чем сравнивать");
            return null;
            
        }
        
        [HttpGet]
        [Route("[controller]/GetExamples")]
        public List<UserApp> GetExamples() 
        {
            CompanyContext db = new();
            Group group = new Group();
            List<Application> applications = db.Applications.ToList();
            List<UserApp> result = new List<UserApp>();
            int i = 0;
            foreach (Application application in applications)
            {
                if (application.Approved != null)
                {
                    Group? refGroup = db.Groups.Where(t => t.Id == application.GroupId).Select(t => t).FirstOrDefault();
                    if (refGroup != null)
                    {
                        Appointment? app = db.Appointments.Where(t => t.Id == refGroup.Appointment).Select(t => t).FirstOrDefault();
                        if (app != null)
                        {
                            string? date = app.DateOfVisit;
                            Employe? emp = db.Employes.Where(t => t.EmployeeCode == app.EmployeId).Select(t => t).FirstOrDefault();
                            if (emp != null)
                            {
                                Departament? department = db.Departaments.Where(t => t.Id == emp.Departament).Select(t => t).FirstOrDefault();
                                string? findDep = department?.Departament1;
                                UserApp item = new UserApp()
                                {
                                    Type = application.TypeApplication,
                                    Departament = findDep,
                                    Date = date,
                                    Status = application?.Approved,
                                    Reason = application?.Reason
                                };
                                result.Add(item);
                                i++;
                                if (i > 4)
                                {
                                    return result;
                                }
                                
                            }
                        }
                    }

                }
            }
            return result;
        }

        [HttpGet]
        [Route("[controller]/PostApproved")]
        public void PostApproved(bool status, string data, string time, int Id)
        {
            CompanyContext db = new CompanyContext();
            Application application = db.Applications.ToList().First(a => a.Id == Id);
            if (application != null)
            {
                application.Approved = status;
                Group? refGroup = db.Groups.Where(t => t.Id == application.GroupId).Select(t => t).FirstOrDefault();
                if (refGroup != null)
                {
                    Appointment? app = db.Appointments.Where(t => t.Id == refGroup.Appointment).Select(t => t).FirstOrDefault();
                    if (app != null)
                    {
                        app.DateOfVisit = data;
                        app.TimeOfVisit = time;
                        db.SaveChanges();
                    }
                }
            }
        }
        [HttpGet]
        [Route("[controller]/PostSecurityInformation")]
        public void PostSecurityInformation(bool status, string time, int Id)
        {
            CompanyContext db = new CompanyContext();
            Application application = db.Applications.ToList().First(a => a.Id == Id);
            if (application != null)
            {
                application.Visited = status;
                application.DepartureTime = time;
                db.SaveChanges();
            }
        }
    }

}

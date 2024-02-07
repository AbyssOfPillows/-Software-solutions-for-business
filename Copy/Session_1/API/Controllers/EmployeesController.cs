using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("/employees")]
    public class EmployeesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            KeeperBdContext db = new KeeperBdContext();
            List<Employee> employees = db.Employees.ToList();
            return Ok(employees);
        }
        [HttpGet]
        [Route("Departament={Departament}&Fio={Fio}")]
        public IActionResult Get(string Departament, string Fio)
        {
            KeeperBdContext db = new KeeperBdContext();
            Departament departament = db.Departaments.Single(d => d.Name == Departament);
            string[] fio = Fio.Split(" ");
            Employee? employee = db.Employees.SingleOrDefault(e => e.Surname == fio[0] && e.Name == fio[1]);
            if (employee == null || employee.DepartmentId != departament.Id)
            {
                return BadRequest("Такого сотрудника не существует");
            }
            return Ok(employee);
        }
    }
}

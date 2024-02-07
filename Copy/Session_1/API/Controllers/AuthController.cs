using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : Controller
    {
        [HttpGet]
        [Route("login={login}&password={password}")]
        public IActionResult Auth(string login, string password)
        {
            KeeperBdContext keeperBdContext = new KeeperBdContext();
            Visitor? visitor = keeperBdContext.Visitors.FirstOrDefault(l => l.Login == login);
            if (visitor == null)
            {
                return NotFound("Не найден");
            }
            /*
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            string passwordMD5 = "";
            foreach (byte b in bytes)
            {
                passwordMD5 = passwordMD5 + (b.ToString());
            }
            if (visitor.Password != passwordMD5)
            {
                return BadRequest("Доступа не будет!");
            }
            */
            if (visitor.Password != password)
            {
                return BadRequest("Доступа не будет!");
            }
            return Ok("Доступ есть");
        }
        [HttpGet]
        [Route("{code}")]
        public IActionResult AuthGeneralDepartamentEmployee(int code)
        {
            KeeperBdContext db = new KeeperBdContext();
            Employee? employee = db.Employees.FirstOrDefault(e => e.Code == code);
            if (employee == null)
            {
                return BadRequest("Такого сотрудника не существует");
            }
            if (employee.DepartmentId != 6)
            {
                return BadRequest("Сотрудник не имеет доступа");
            }
            return Ok("Ok");
        }
    }
}

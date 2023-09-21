using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        CompanyV2Context db;
        public UsersController(CompanyV2Context context)
        {
            db = context;

        }
            
        [HttpPost]

        public ActionResult PostUser(User user)
        {
            if(user == null) 
            {
                return BadRequest();
            }
            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }
    }
}

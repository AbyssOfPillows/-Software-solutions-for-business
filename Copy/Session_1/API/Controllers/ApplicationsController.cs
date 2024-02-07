using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("/applications")]
    public class ApplicationsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            KeeperBdContext db = new KeeperBdContext();
            List<Application> applications = db.Applications.ToList();
            return Ok(applications);
        }
        [HttpPut]
        public IActionResult Put(List<Application> applications)
        {
            KeeperBdContext keeperBdContext = new KeeperBdContext();
            keeperBdContext.Update(applications);
            return Ok("Всё сохранено");
        }
        [HttpPost]
        public IActionResult Post(Application applications)
        {
            KeeperBdContext keeperBdContext = new KeeperBdContext();
            keeperBdContext.Applications.Add(applications);
            return Ok(applications);
        }
    }
}

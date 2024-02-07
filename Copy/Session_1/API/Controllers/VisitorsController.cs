using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Text.Json;


namespace API.Controllers
{
    [ApiController]
    [Route("/visitors")]
    public class VisitorsController : ControllerBase
    {
        // /visitors/2
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            KeeperBdContext keeperBdContext = new KeeperBdContext();
            Visitor? visitor = keeperBdContext.Visitors.Find(id);
            if(visitor == null)
            {
                return NotFound();
            }
            return Ok(visitor);
        }
        [HttpGet]
        public IActionResult GetVisitors()
        {
            KeeperBdContext db = new KeeperBdContext();
            List<Visitor> visitors = db.Visitors.ToList();
            return Ok(visitors);
        }
        [HttpPut]
        public IActionResult Put(Visitor visitor)
        {
            KeeperBdContext db = new KeeperBdContext();
            db.Visitors.Update(visitor);
            db.SaveChanges();
            return Ok(visitor);
        }
        [HttpPost]
        public IActionResult Post(Visitor visitor)
        {
            KeeperBdContext db = new KeeperBdContext();
            if(db.Visitors.FirstOrDefault(v => v.Login == visitor.Login) != null)
            {
                return BadRequest("Пользователь существует");
            }
            db.Visitors.Add(visitor);
            db.SaveChanges();
            return Ok(visitor);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            KeeperBdContext db = new KeeperBdContext();
            Visitor? visitor = db.Visitors.Find(id);
            try
            {
                db.Visitors.Remove(visitor!);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Success!");
        }
        
    }
}

using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Xml.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("Groups")]
    public class GroupsController : Controller
    {
        [HttpPost]
        public IActionResult Post(Visitor visitor)
        {
            KeeperBdContext db = new KeeperBdContext();
            Group newGroup = new Group();
            Group? group = db.Groups.OrderBy(g => g.Id).LastOrDefault();
            if (group == null)
            {
                newGroup.Name = "ГР_1";
            }
            int num = Convert.ToInt16((group!.Name.ToString().Split("_")[1]) + 1);
            newGroup.Name = "ГР_" + num.ToString();
            newGroup.Visitors.Add(visitor);
            db.Groups.Add(newGroup);
            db.SaveChanges();
            return Ok(newGroup);

        }
        [HttpPut]
        [Route("{GroupId}")]
        public IActionResult Put(Visitor visitor, int GroupId)
        {
            KeeperBdContext db = new KeeperBdContext();
            Group? group = db.Groups.Find(GroupId);
            if(group == null)
            {
                return BadRequest("Такой группы не существует");
            }
            group.Visitors.Add(visitor);
            db.SaveChanges();
            return Ok(visitor);

        }
    }
}
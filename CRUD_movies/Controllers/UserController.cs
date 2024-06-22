using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_movies.Controllers;
[Route("[controller]/[action]")]
public class UserController : Controller
{
    DataBaseContext db;

    public UserController(DataBaseContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetById(long id)
    {
        var user = db.Users
            .Include(x => x.Movies)
            .FirstOrDefault(x => x.Id == id);
        return Ok(user);
    }

    [HttpGet]
    public IActionResult GetByName(string name)
    {
        var user = db.Users
            .Include(x => x.Movies)
            .FirstOrDefault(x => x.Name == name);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult AddUser(User user)
    {
        db.Users.Add(user);
        db.SaveChanges();
        return Ok();
    }
    [HttpPost]
    public IActionResult UpdateUser(User user)
    {
        db.Users.Update(user);
        db.SaveChanges();
        return Ok();
    }
    [HttpPost]
    public IActionResult DeleteUser(long id)
    {
        var user = db.Users.FirstOrDefault(x => x.Id == id);
        db.Remove(user);
        return Ok();
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_movies.Controllers;
[Route("[action]")]
public class LikeController : Controller
{
    DataBaseContext db;

    public LikeController(DataBaseContext context)
    {
        db = context;
    }

    [HttpPost]
    public IActionResult Like(long userId, long movieId)
    {
        var user = db.Users.FirstOrDefault(x => x.Id == userId);
        var movie = db.Movies.FirstOrDefault(x => x.Id == movieId);
        user.Movies.Add(movie);
        db.SaveChanges();
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Dislike(long userId, long movieId)
    {
        var user = db.Users
            .Include(x => x.Movies)
            .FirstOrDefault(x => x.Id == userId);
        var movie = db.Movies.FirstOrDefault(x => x.Id == movieId);
        user.Movies.Remove(movie);
        db.SaveChanges();
        return Ok();
    }
}
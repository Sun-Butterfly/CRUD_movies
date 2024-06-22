using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_movies.Controllers;
[Route("[controller]/[action]")]
public class MovieController : Controller
{
    DataBaseContext db;

    public MovieController(DataBaseContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetById(long id)
    {
        var movie = db.Movies
            .Include(x => x.Users)
            .FirstOrDefault(x => x.Id == id);
        return Ok(movie);
    }

    [HttpGet]
    public IActionResult GetByName(string name)
    {
        var movie = db.Movies
            .Include(x => x.Users)
            .FirstOrDefault(x => x.Name == name);
        return Ok(movie);
    }

    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        db.Movies.Add(movie);
        db.SaveChanges();
        return Ok();
    }

    [HttpPost]
    public IActionResult UpdateMovie(Movie movie)
    {
        db.Movies.Update(movie);
        db.SaveChanges();
        return Ok();
    }

    [HttpPost]
    public IActionResult DeleteMovie(long id)
    {
        var movie = db.Movies.FirstOrDefault(x => x.Id == id);
        db.Remove(movie);
        db.SaveChanges();
        return Ok();
    }
}
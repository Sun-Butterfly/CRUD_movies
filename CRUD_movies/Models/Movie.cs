namespace CRUD_movies;

public class Movie
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? AgeRating { get; set; }
    public List<User> Users { get; set; } = new List<User>();
}
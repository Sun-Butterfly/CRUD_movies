namespace CRUD_movies;

public class User
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public List<Movie> Movies { get; set; } = new List<Movie>();
}
namespace Movies.Api.Movies;

public class Movie {
  public int Id { get; set; }
  public required string Title { get; set; }
  public int ReleaseYear { get; set; }
}

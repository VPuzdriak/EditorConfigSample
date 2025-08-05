using EditorConfig.Api;

using Microsoft.EntityFrameworkCore;

namespace Movies.Api.Movies.GetMovies;

public class GetMoviesEndpoint : IEndpoint {
  public string Tag { get; } = "Movies";

  public void Map(IEndpointRouteBuilder builder) {
    builder.MapGet("/movies", async (MoviesDbContext context) => {
        var movies = await context.Movies.ToListAsync();
        return Results.Ok(movies);
      }).WithOpenApi()
      .Produces<IEnumerable<Movie>>()
      .WithName("GetMovies")
      .WithTags(Tag);
    
  }
}

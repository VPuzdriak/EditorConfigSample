using Microsoft.EntityFrameworkCore;

namespace EditorConfig.Api.Movies.GetMovies;

public class GetMoviesEndpoint : IEndpoint {
  public void Map(IEndpointRouteBuilder builder) {
    builder.MapGet("/movies", async (MoviesDbContext context) => {
      var movies = await context.Movies.ToListAsync();
      return Results.Ok(movies);
    }).WithOpenApi()
      .Produces<IEnumerable<Movie>>()
      .WithName("GetMovies")
      .WithTags("Movies");
  }
}

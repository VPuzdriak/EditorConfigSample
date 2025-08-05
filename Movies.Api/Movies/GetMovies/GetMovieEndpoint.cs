using EditorConfig.Api;

namespace Movies.Api.Movies.GetMovies;

public class GetMovieEndpoint : IEndpoint {
  public string Tag { get; } = "Movies";

  public void Map(IEndpointRouteBuilder builder) {
    builder.MapGet("/movies/{movieId:int}", async (MoviesDbContext context, int movieId) => {
        var movie = await context.Movies.FindAsync(movieId);
        return movie is null ? Results.NotFound() : Results.Ok(movie);
      })
      .WithOpenApi()
      .Produces<Movie>()
      .Produces(404)
      .WithName("GetMovie")
      .WithTags(Tag);
  }
}

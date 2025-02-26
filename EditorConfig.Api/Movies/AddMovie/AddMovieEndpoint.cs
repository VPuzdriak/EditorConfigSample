using MediatR;

namespace EditorConfig.Api.Movies.AddMovie;

public class AddMovieEndpoint : IEndpoint {
  public void Map(IEndpointRouteBuilder builder) {
    builder.MapPost("/movies", async (Movie movie, IMediator mediator) => {
      await mediator.Send(new AddMovieCommand(movie));
      return Results.Created();
    });
  }
}

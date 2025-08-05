using EditorConfig.Api;

using MediatR;

namespace Movies.Api.Movies.AddMovie;

public class AddMovieEndpoint : IEndpoint {
  public string Tag { get; } = "Movies";

  public void Map(IEndpointRouteBuilder builder) {
    builder.MapPost("/movies", async (Movie movie, IMediator mediator) => {
      await mediator.Send(new AddMovieCommand(movie));
      return Results.Created();
    })
    .WithTags(Tag);
  }
}

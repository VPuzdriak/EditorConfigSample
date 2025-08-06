using System;
using System.Threading;
using System.Threading.Tasks;

using Movies.Api.Client.Contracts;

using Tickets.DataAccess;

namespace Tickets.ApplicationService {
  public class TicketsService {
    // This line will be an IntelliSence error in VS, but just suggestion in Rider.
    // Does not break the build because the non-SDK projects are not supporting this rule
    private MoviesRepository _moviesRepository;

    public TicketsService(MoviesRepository moviesRepository) {
      _moviesRepository = moviesRepository;
    }

    public async Task BuyTicket(int movieId) {
      // Simulate some business logic
      Movie movie = await _moviesRepository.GetMovieAsync(movieId, CancellationToken.None).ConfigureAwait(false) ?? throw new ArgumentException($"Movie with ID {movieId} does not exist.");

      if (movie is null) {
        return;
      }
      
      // Here you would typically have more logic, like checking availability, processing payment, etc.
      // For now, we just simulate a successful ticket purchase.
      Console.WriteLine($"Ticket purchased for movie: {movie.Title} (ID: {movie.Id})");
    }
  }
}

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using Tickets.DataAccess;

namespace Tickets.ApplicationService {
  public class TicketsService {
    private readonly MoviesRepository _moviesRepository;

    public TicketsService(MoviesRepository moviesRepository) {
      _moviesRepository = moviesRepository;
    }

    public async Task BuyTicket(int movieId) {
      // Simulate some business logic
      var movie = await _moviesRepository.GetMovieAsync(movieId, CancellationToken.None).ConfigureAwait(false) ?? throw new ArgumentException($"Movie with ID {movieId} does not exist.");

      // Here you would typically have more logic, like checking availability, processing payment, etc.
      // For now, we just simulate a successful ticket purchase.
      Console.WriteLine($"Ticket purchased for movie: {movie.Title} (ID: {movie.Id})");
    }
  }
}

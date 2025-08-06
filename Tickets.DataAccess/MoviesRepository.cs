using System.Threading;
using System.Threading.Tasks;

using Movies.Api.Client;
using Movies.Api.Client.Contracts;

namespace Tickets.DataAccess {
  public class MoviesRepository {
    private readonly Client _client;

    public MoviesRepository(Client client) {
      _client = client;
    }

    public async Task<Movie> GetMovieAsync(int movieId, CancellationToken cancellationToken) {
      // Simulate a build break due to a non-reachable code path
      // if (false) {
      //   return new Movie();
      // }

      return await _client.GetMovieAsync(movieId, cancellationToken).ConfigureAwait(false);
    }
  }
}

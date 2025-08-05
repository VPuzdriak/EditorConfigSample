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
      return await _client.GetMovieAsync(movieId, cancellationToken).ConfigureAwait(false);
    }
  }
}

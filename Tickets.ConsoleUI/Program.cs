using System.Net.Http;
using System.Threading.Tasks;

using Movies.Api.Client;

using Tickets.ApplicationService;
using Tickets.DataAccess;

namespace Tickets.ConsoleUI {
  internal class Program {
    public static async Task Main(string[] args) {
      var client = new Client("https://localhost:7233", new HttpClient());
      var moviesRepository = new MoviesRepository(client);
      var service = new TicketsService(moviesRepository);
      await service.BuyTicket(movieId: 1);
    }
  }
}

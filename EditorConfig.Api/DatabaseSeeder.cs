using EditorConfig.Api.Movies;

using Microsoft.EntityFrameworkCore;

namespace EditorConfig.Api;

public static class DatabaseSeeder {
  public static async Task SeedAsync(this MoviesDbContext context, CancellationToken ct) {
    ArgumentNullException.ThrowIfNull(context);

    if (await context.Movies.AnyAsync(ct)) {
      return;
    }

    Movie[] movies = [
      new() { Id = 1, Title = "The Shawshank Redemption", ReleaseYear = 1994 },
      new() { Id = 2, Title = "The Godfather", ReleaseYear = 1972 },
      new() { Id = 3, Title = "The Dark Knight", ReleaseYear = 2008 }
    ];

    await context.Movies.AddRangeAsync(movies, ct);
    await context.SaveChangesAsync(ct);
  }
}

using Microsoft.EntityFrameworkCore;

namespace EditorConfig.Api.Movies;

public class MoviesDbContext : DbContext {
  public DbSet<Movie> Movies { get; set; }

  public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) {
  }
}

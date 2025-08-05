using System.Reflection;

using Movies.Api.Movies;

namespace EditorConfig.Api;

public static class ApplicationBuilderExtensions {
  public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder) {
    var currentAssembly = Assembly.GetExecutingAssembly();
    var endpointType = typeof(IEndpoint);

    foreach (var type in currentAssembly.GetTypes()) {
      if (endpointType.IsAssignableFrom(type) && !type.IsInterface) {
        var endpoint = (IEndpoint)Activator.CreateInstance(type)!;
        endpoint.Map(builder);
      }
    }

    return builder;
  }

  public static async Task EnsureDatabaseCreatedAsync(this IApplicationBuilder builder) {
    ArgumentNullException.ThrowIfNull(builder);

    await using var scope = builder.ApplicationServices.CreateAsyncScope();

    var context = scope.ServiceProvider.GetRequiredService<MoviesDbContext>();
    await context.Database.EnsureCreatedAsync();

    await context.SeedAsync(CancellationToken.None);
  }
}

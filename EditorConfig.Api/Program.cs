using System.Reflection;

using EditorConfig.Api;
using EditorConfig.Api.Movies;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument();

builder.Services.AddDbContext<MoviesDbContext>(options => options.UseInMemoryDatabase("Movies"));
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();

app.UseHttpsRedirection();

await app.EnsureDatabaseCreatedAsync();
app.MapEndpoints();

await app.RunAsync();

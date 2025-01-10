using System.Reflection;
using EditorConfig.Api;
using EditorConfig.Api.Movies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MoviesDbContext>(options =>
    options.UseInMemoryDatabase("Movies"));

builder.Services.AddMediatR(config =>
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

await app.EnsureDatabaseCreatedAsync();
app.MapEndpoints();

await app.RunAsync();
using MediatR;

using Microsoft.EntityFrameworkCore;

namespace EditorConfig.Api.Movies.AddMovie;

public record AddMovieCommand(Movie Movie) : IRequest;

public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand>
{
    private readonly MoviesDbContext _context;

    public AddMovieCommandHandler(MoviesDbContext context)
    {
        _context = context;
    }

    public async Task Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var movieWasAlreadyAdded =
            await _context.Movies.FirstOrDefaultAsync(m => m.Id == request.Movie.Id, cancellationToken);
        if (movieWasAlreadyAdded is not null)
        {
            throw new InvalidOperationException("Movie already exists");
        }

        await _context.Movies.AddAsync(request.Movie, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
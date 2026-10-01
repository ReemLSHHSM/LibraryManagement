using LibraryManagement.Application.Common.Interfaces;
using Mapster;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Queries.GetAuthor
{
  public class GetAuthorByIdAsyncHandler
      : IRequestHandler<GetAuthorByIdAsync, AuthorDto?>
  {
    private readonly ILibraryDbContext _context;

    public GetAuthorByIdAsyncHandler(
        ILibraryDbContext context)
    {
      _context = context;
    }

    public async Task<AuthorDto?> Handle(
        GetAuthorByIdAsync request,
        CancellationToken cancellationToken)
    {
      var author = await _context.Authors.FindAsync(
          [request.id],
          cancellationToken
      );

      if (author is null)
      {
        return null;
      }

      return author.Adapt<AuthorDto>();
    }
  }
}

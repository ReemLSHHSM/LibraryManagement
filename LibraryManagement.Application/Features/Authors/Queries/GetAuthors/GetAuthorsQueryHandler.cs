using LibraryManagement.Application.Common.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Authors.Queries.GetAuthors
{
  public class GetAuthorsQueryHandler
      : IRequestHandler<GetAuthorsQuery, List<AuthorDto>>
  {
    private readonly ILibraryDbContext _context;

    public GetAuthorsQueryHandler(
        ILibraryDbContext context)
    {
      _context = context;
    }

    public async Task<List<AuthorDto>> Handle(
        GetAuthorsQuery request,
        CancellationToken cancellationToken)
    {
      var authors = await _context.Authors
          .ToListAsync(cancellationToken);

      return authors.Adapt<List<AuthorDto>>();
    }
  }
}

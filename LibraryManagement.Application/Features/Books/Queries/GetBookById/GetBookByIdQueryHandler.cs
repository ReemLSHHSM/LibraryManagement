using LibraryManagement.Application.Common.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Queries.GetBookById;

public class GetBookByIdQueryHandler
    : IRequestHandler<GetBookByIdQuery, BookDto?>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public GetBookByIdQueryHandler(ILibraryDbContext libraryDbContext)
  {
        _libraryDbContext = libraryDbContext;
  }

  public async Task<BookDto?> Handle(
      GetBookByIdQuery request,
      CancellationToken cancellationToken)
  {
    var book = await _libraryDbContext.Books.FirstOrDefaultAsync(
        b => b.Id == request.Id,
        cancellationToken);

    if (book == null)
      return null;

    return book.Adapt<BookDto>();
  }
}

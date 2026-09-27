using LibraryManagement.Application.Common.Interfaces;
using Mapster;
using MediatR;

namespace LibraryManagement.Application.Books.Queries.GetBookById;

public class GetBookByIdQueryHandler
    : IRequestHandler<GetBookByIdQuery, BookDto?>
{
  private readonly IBookRepository _bookRepository;

  public GetBookByIdQueryHandler(IBookRepository bookRepository)
  {
    _bookRepository = bookRepository;
  }

  public async Task<BookDto?> Handle(
      GetBookByIdQuery request,
      CancellationToken cancellationToken)
  {
    var book = await _bookRepository.GetBookByIdAsync(
        request.Id,
        cancellationToken);

    if (book == null)
      return null;

    return book.Adapt<BookDto>();
  }
}

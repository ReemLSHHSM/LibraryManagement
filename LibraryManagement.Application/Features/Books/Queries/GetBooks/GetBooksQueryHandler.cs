using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Features.Books;
using Mapster;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Queries.GetBooks;

public class GetBooksQueryHandler
    : IRequestHandler<GetBooksQuery, List<BookDto>>
{
    private readonly IBookRepository _bookRepository;

    public GetBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookDto>> Handle(
        GetBooksQuery request,
        CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetBooksAsync(cancellationToken);

        return books.Adapt<List<BookDto>>();
    }
}

using LibraryManagement.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Mapster;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Queries.GetBooks;

public class GetBooksQueryHandler
    : IRequestHandler<GetBooksQuery, List<BookDto>>
{
    private readonly ILibraryDbContext _libraryDbContext;

    public GetBooksQueryHandler(ILibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }
    
    public async Task<List<BookDto>> Handle(
        GetBooksQuery request,
        CancellationToken cancellationToken)
    {
        var books = await _libraryDbContext.Books.ToListAsync(cancellationToken);

        return books.Adapt<List<BookDto>>();
    }
}

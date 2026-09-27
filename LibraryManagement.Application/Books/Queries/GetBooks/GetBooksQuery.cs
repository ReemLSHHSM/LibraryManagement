using MediatR;

namespace LibraryManagement.Application.Books.Queries.GetBooks;

public record GetBooksQuery : IRequest<List<BookDto>>;

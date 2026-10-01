using LibraryManagement.Application.Features.Books;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Queries.GetBooks;

public record GetBooksQuery : IRequest<List<BookDto>>;

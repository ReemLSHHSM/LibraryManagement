using LibraryManagement.Application.Features.Books;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Queries.GetBookById;

public record GetBookByIdQuery(int Id) : IRequest<BookDto?>;

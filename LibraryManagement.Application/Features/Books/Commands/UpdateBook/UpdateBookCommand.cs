using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands.UpdateBook;

public record UpdateBookCommand(
    int Id,
    string Title,
    string ISBN,
    DateTime PublishedDate,
    int AuthorId,
    bool IsAvailable
) : IRequest<bool>;

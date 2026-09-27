using MediatR;

namespace LibraryManagement.Application.Books.Commands.UpdateBook;

public record UpdateBookCommand(
    int Id,
    string Title,
    string ISBN,
    DateTime PublishedDate,
    int AuthorId,
    bool IsAvailable
) : IRequest<bool>;

using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands.DeleteBookCommand;

public record DeleteBookCommand(int Id) : IRequest<bool>;

using LibraryManagement.Application.Common.Interfaces;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands.DeleteBookCommand;

public class DeleteBookCommandHandler
    : IRequestHandler<DeleteBookCommand, bool>
{
  private readonly IBookRepository _bookRepository;

  public DeleteBookCommandHandler(IBookRepository bookRepository)
  {
    _bookRepository = bookRepository;
  }

  public async Task<bool> Handle(
      DeleteBookCommand request,
      CancellationToken cancellationToken)
  {
    return await _bookRepository.DeleteBookAsync(
        request.Id,
        cancellationToken);
  }
}

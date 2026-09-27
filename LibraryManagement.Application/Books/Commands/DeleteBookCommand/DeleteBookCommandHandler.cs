using LibraryManagement.Application.Common.Interfaces;
using MediatR;

namespace LibraryManagement.Application.Books.Commands.DeleteBook;

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

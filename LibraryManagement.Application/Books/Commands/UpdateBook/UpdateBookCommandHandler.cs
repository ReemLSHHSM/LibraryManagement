using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace LibraryManagement.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler
    : IRequestHandler<UpdateBookCommand, bool>
{
  private readonly IBookRepository _bookRepository;

  public UpdateBookCommandHandler(IBookRepository bookRepository)
  {
    _bookRepository = bookRepository;
  }

  public async Task<bool> Handle(
      UpdateBookCommand request,
      CancellationToken cancellationToken)
  {
    var book = request.Adapt<Book>();

    return await _bookRepository.UpdateBookAsync(
        book,
        cancellationToken);
  }
}

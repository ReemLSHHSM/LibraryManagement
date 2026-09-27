using LibraryManagement.Application.Authors.Commands.DeleteAuthor;
using LibraryManagement.Application.Common.Interfaces;
using MediatR;

public class DeleteAuthorCommandHandler
    : IRequestHandler<DeleteAuthorCommand, bool>
{
  private readonly IAuthorRepository _authorRepository;

  public DeleteAuthorCommandHandler(
      IAuthorRepository authorRepository)
  {
    _authorRepository = authorRepository;
  }

  public async Task<bool> Handle(
      DeleteAuthorCommand request,
      CancellationToken cancellationToken)
  {
    return await _authorRepository.DeleteAuthorAsync(
        request.Id,
        cancellationToken);
  }
}

using LibraryManagement.Application.Common.Interfaces;
using Mapster;
using MediatR;

namespace LibraryManagement.Application.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler
    : IRequestHandler<UpdateAuthorCommand, bool>
{
  private readonly IAuthorRepository _authorRepository;

  public UpdateAuthorCommandHandler(
      IAuthorRepository authorRepository)
  {
    _authorRepository = authorRepository;
  }

  public async Task<bool> Handle(
      UpdateAuthorCommand request,
      CancellationToken cancellationToken)
  {
    var author = await _authorRepository.GetAuthorByIdAsync(
        request.Id,
        cancellationToken);

    if (author == null)
    {
      return false;
    }

    request.Adapt(author);

    return await _authorRepository.UpdateAuthorAsync(
        author,
        cancellationToken);
  }
}

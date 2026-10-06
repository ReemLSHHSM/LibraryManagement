using LibraryManagement.Application.Common.Dtos;
using LibraryManagement.Application.Common.Interfaces;
using MediatR;

namespace LibraryManagement.Application.Features.ExternalBooks.Commands
{
  public record CreateExternalBookCommand(
      string Title,
      string? Author,
      string? Category,
      int? PublishedYear
  ) : IRequest;

  public class CreateExternalBookCommandHandler
      : IRequestHandler<CreateExternalBookCommand>
  {
    private readonly IExternalBookService _externalBookService;

    public CreateExternalBookCommandHandler(
        IExternalBookService externalBookService)
    {
      _externalBookService = externalBookService;
    }

    public async Task Handle(
        CreateExternalBookCommand request,
        CancellationToken cancellationToken)
    {
      var book = new CreateExternalBookDto
      {
        Title = request.Title,
        Author = request.Author,
        Category = request.Category,
        PublishedYear = request.PublishedYear
      };

      await _externalBookService.CreateBookAsync(
          book,
          cancellationToken);
    }
  }
}

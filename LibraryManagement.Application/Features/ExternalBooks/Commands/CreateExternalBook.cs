using FluentValidation;
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

  public class CreateExternalBookCommandValidator
      : AbstractValidator<CreateExternalBookCommand>
  {
    public CreateExternalBookCommandValidator()
    {
      RuleFor(x => x.Title)
          .NotEmpty()
          .WithMessage("Title is required.")
          .MinimumLength(2)
          .WithMessage("Title must be at least 2 characters.")
          .MaximumLength(200)
          .WithMessage("Title must not exceed 200 characters.");

      RuleFor(x => x.Author)
          .MaximumLength(100)
          .WithMessage("Author must not exceed 100 characters.");

      RuleFor(x => x.Category)
          .MaximumLength(100)
          .WithMessage("Category must not exceed 100 characters.");

      RuleFor(x => x.PublishedYear)
          .GreaterThan(0)
          .WithMessage("Published year must be greater than 0.")
          .LessThanOrEqualTo(DateTime.UtcNow.Year)
          .WithMessage("Published year cannot be in the future.")
          .When(x => x.PublishedYear.HasValue);
    }
  }
}

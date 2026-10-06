using FluentValidation;

namespace LibraryManagement.Application.Features.Books.Commands.CreateBook
{
  public class CreateBookCommandValidator :
    AbstractValidator<CreateBookCommand>
  {

    public CreateBookCommandValidator()
    {
      RuleFor(b => b.Title)
        .NotEmpty()
        .MaximumLength(200)
        .WithMessage("Book title is required and must not exceed 200 characters.");


      RuleFor(b => b.ISBN)
        .NotEmpty()
        .WithMessage("Book ISBN is required.");

      RuleFor(b => b.PublishedDate)
        .LessThanOrEqualTo(DateTime.Now)
        .WithMessage("Published date cannot be in the future.");


    }

  }
}

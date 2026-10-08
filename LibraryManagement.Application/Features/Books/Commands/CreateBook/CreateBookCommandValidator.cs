using FluentValidation;

namespace LibraryManagement.Application.Features.Books.Commands.CreateBook
{
  public class CreateBookCommandValidator :
    AbstractValidator<CreateBookCommand>
  {

    public CreateBookCommandValidator()
    {
      RuleFor(b => b.CreateBookDto.Title)
        .NotEmpty()
        .MaximumLength(200)
        .WithMessage("Book title is required and must not exceed 200 characters.")
        .MinimumLength(50)
        .WithMessage("Book title must be at least 50 characters long.");


      RuleFor(b => b.CreateBookDto.ISBN)
        .NotEmpty()
        .WithMessage("Book ISBN is required.");

      RuleFor(b => b.CreateBookDto.PublishedDate)
        .LessThanOrEqualTo(DateTime.Now)
        .WithMessage("Published date cannot be in the future.");

      RuleFor(b => b.CreateBookDto.AuthorId)
        .GreaterThan(0)
        .WithMessage("Author Id must be greater than 0.");


    }

  }
}

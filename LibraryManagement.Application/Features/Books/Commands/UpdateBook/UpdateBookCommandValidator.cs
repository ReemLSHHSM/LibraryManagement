using FluentValidation;

namespace LibraryManagement.Application.Features.Books.Commands.UpdateBook
{
  public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
  {
    public UpdateBookCommandValidator()
    {
      RuleFor(x => x.Id)
        .NotEmpty()
        .WithMessage("Book Id is required.");

      RuleFor(x => x.Title)
        .NotEmpty()
        .MaximumLength(200)
        .WithMessage("Book title is required and must not exceed 200 characters.")
        .MinimumLength(50)
        .WithMessage("Book title must be at least 50 characters long.");

      RuleFor(x => x.ISBN)
        .NotEmpty()
        .WithMessage("Book ISBN is required.");

      RuleFor(x => x.AuthorId)
        .GreaterThan(0)
        .WithMessage("Author Id must be greater than 0.");

      RuleFor(x => x.PublishedDate)
        .LessThanOrEqualTo(DateTime.Now)
        .WithMessage("Published date cannot be in the future.");
    }
  }
}

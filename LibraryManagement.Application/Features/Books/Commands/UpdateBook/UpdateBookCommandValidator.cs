using FluentValidation;

namespace LibraryManagement.Application.Features.Books.Commands.UpdateBook
{
  public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
  {
    public UpdateBookCommandValidator()
    {
      RuleFor(x => x.Id)
        .GreaterThan(0).WithMessage("Book Id must be greater than 0.");
      RuleFor(x => x.Title)
        .NotEmpty()
        .MaximumLength(200)
        .WithMessage("Book title is required and must not exceed 200 characters.");
      RuleFor(x => x.AuthorId)
        .GreaterThan(0).WithMessage("Author Id must be greater than 0.");
    }
  }
}

using FluentValidation;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandValidator
    : AbstractValidator<CreateAuthorCommand>
{
  public CreateAuthorCommandValidator()
  {
    RuleFor(x => x.CreateAuthorDto.Name)
        .NotEmpty()
        .MaximumLength(100)
        .WithMessage("Author name is required and must not exceed 100 characters.");

    RuleFor(x => x.CreateAuthorDto.Bio)
        .MaximumLength(1000)
        .NotEmpty();
  }
}

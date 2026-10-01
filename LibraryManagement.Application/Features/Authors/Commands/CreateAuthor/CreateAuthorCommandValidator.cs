using FluentValidation;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandValidator
    : AbstractValidator<CreateAuthorCommand>
{
  public CreateAuthorCommandValidator()
  {
    RuleFor(x => x.Name)
        .NotEmpty()
        .MaximumLength(100);

    RuleFor(x => x.Bio)
        .MaximumLength(1000)
        .NotEmpty();
  }
}

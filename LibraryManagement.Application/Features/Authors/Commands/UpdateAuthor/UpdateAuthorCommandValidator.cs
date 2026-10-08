using FluentValidation;

namespace LibraryManagement.Application.Features.Authors.Commands.UpdateAuthor
{
  public class UpdateAuthorCommandValidator :
      AbstractValidator<UpdateAuthorCommand>
  {


    public UpdateAuthorCommandValidator()
    {
      RuleFor(x => x.Id)
          .GreaterThan(0)
          .WithMessage("Author Id must be greater than 0.");

      RuleFor(x => x.Name)
          .NotEmpty().WithMessage("Author Name is required.")
          .MaximumLength(100).WithMessage("Author Name must not exceed 100 characters.")
          .MinimumLength(2).WithMessage("Author Name must be at least 2 characters long.");

      RuleFor(x => x.Bio)
          .MaximumLength(1000).WithMessage("Author Bio must not exceed 1000 characters.")
          .NotEmpty().WithMessage("Author Bio is required.");


    }
  }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Features.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator :
        AbstractValidator<UpdateAuthorCommand>
    {


        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Author Id is required.")
                .GreaterThan(0).WithMessage("Author Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Author Name is required.")
                .MaximumLength(100).WithMessage("Author Name must not exceed 100 characters.");

            RuleFor(x => x.Bio)
                .MaximumLength(1000).WithMessage("Author Bio must not exceed 1000 characters.")
                .NotEmpty().WithMessage("Author Bio is required.");

        }
    }
}

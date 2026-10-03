using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Features.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator:AbstractValidator<DeleteAuthorCommand>
    {

        public DeleteAuthorCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Author Id must be greater than 0.");
        }
    }
}

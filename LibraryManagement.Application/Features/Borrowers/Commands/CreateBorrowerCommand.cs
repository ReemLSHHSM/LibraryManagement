using FluentValidation;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Features.Borrowers.Commands.CreateBorrower;

public class CreateBorrowerCommand : IRequest<int>
{
  public CreateBorrowerDto Borrower { get; set; } = new();
}

public class CreateBorrowerCommandHandler
    : IRequestHandler<CreateBorrowerCommand, int>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public CreateBorrowerCommandHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<int> Handle(
      CreateBorrowerCommand request,
      CancellationToken cancellationToken)
  {
    var borrower = new Borrower
    {
      Phone = request.Borrower.Phone,
      UserId = request.Borrower.UserId,
      CreatedAt = DateTime.UtcNow,
      ModifiedAt = DateTime.UtcNow
    };

    await _libraryDbContext.Borrowers.AddAsync(
        borrower,
        cancellationToken);

    await _libraryDbContext.SaveChangesAsync(
        cancellationToken);

    return borrower.Id;
  }
}

public class CreateBorrowerCommandValidator
    : AbstractValidator<CreateBorrowerCommand>
{
  public CreateBorrowerCommandValidator()
  {
    RuleFor(x => x.Borrower.Phone)
        .NotEmpty()
        .WithMessage("Phone number is required.")
        .Matches(@"^\+?[1-9]\d{1,14}$")
        .WithMessage("Invalid phone number format.");

    RuleFor(x => x.Borrower.UserId)
        .GreaterThan(0)
        .WithMessage("User Id must be greater than 0.");
  }
}

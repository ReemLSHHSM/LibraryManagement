using FluentValidation;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Borrowers.Commands.UpdateBorrower;

public class UpdateBorrowerCommand : IRequest<Result>
{
  public int Id { get; set; }

  public string Phone { get; set; } = string.Empty;
}

public class UpdateBorrowerCommandHandler
    : IRequestHandler<UpdateBorrowerCommand, Result>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public UpdateBorrowerCommandHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<Result> Handle(
      UpdateBorrowerCommand request,
      CancellationToken cancellationToken)
  {
    var borrower = await _libraryDbContext.Borrowers
        .FirstOrDefaultAsync(
            b => b.Id == request.Id,
            cancellationToken);

    if (borrower is null)
    {
      return Result.Failure(
          new Error(
              "Borrower.NotFound",
              ErrorType.NotFound,
              $"Borrower with id {request.Id} was not found."));
    }

    borrower.Phone = request.Phone;
    borrower.ModifiedAt = DateTime.UtcNow;

    await _libraryDbContext.SaveChangesAsync(
        cancellationToken);

    return Result.Success();
  }
}

public class UpdateBorrowerCommandValidator
    : AbstractValidator<UpdateBorrowerCommand>
{
  public UpdateBorrowerCommandValidator()
  {
    RuleFor(x => x.Id)
        .GreaterThan(0)
        .WithMessage("Borrower ID must be greater than 0.");

    RuleFor(x => x.Phone)
        .NotEmpty()
        .WithMessage("Phone number is required.")
        .Matches(@"^\+?[1-9]\d{1,14}$")
        .WithMessage("Invalid phone number format.");
  }
}

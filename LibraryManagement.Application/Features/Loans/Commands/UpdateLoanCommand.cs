using FluentValidation;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Loans.Commands.ReturnLoan;

public class ReturnLoanCommand : IRequest<Result>
{
  public int Id { get; set; }
}

public class ReturnLoanCommandHandler
    : IRequestHandler<ReturnLoanCommand, Result>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public ReturnLoanCommandHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<Result> Handle(
      ReturnLoanCommand request,
      CancellationToken cancellationToken)
  {
    var loan = await _libraryDbContext.Loans
        .Include(l => l.Book)
        .FirstOrDefaultAsync(
            l => l.Id == request.Id,
            cancellationToken);

    if (loan is null)
    {
      return Result.Failure(
          new Error(
              "Loan.NotFound",
              ErrorType.NotFound,
              $"Loan with id {request.Id} was not found."));
    }

    if (loan.ReturnDate is not null)
    {
      return Result.Failure(
          new Error(
              "Loan.AlreadyReturned",
              ErrorType.Conflict,
              $"Loan with id {request.Id} has already been returned."));
    }

    loan.ReturnDate = DateTime.UtcNow;
    loan.ModifiedAt = DateTime.UtcNow;

    loan.Book.IsAvailable = true;
    loan.Book.ModifiedAt = DateTime.UtcNow;

    await _libraryDbContext.SaveChangesAsync(
        cancellationToken);

    return Result.Success();
  }
}

public class ReturnLoanCommandValidator
    : AbstractValidator<ReturnLoanCommand>
{
  public ReturnLoanCommandValidator()
  {
    RuleFor(x => x.Id)
        .GreaterThan(0)
        .WithMessage("Loan ID must be greater than 0.");
  }
}

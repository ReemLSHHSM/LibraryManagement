using FluentValidation;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Loans.Commands.DeleteLoan;

public class DeleteLoanCommand : IRequest<Result>
{
  public int Id { get; set; }
}

public class DeleteLoanCommandHandler
    : IRequestHandler<DeleteLoanCommand, Result>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public DeleteLoanCommandHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<Result> Handle(
      DeleteLoanCommand request,
      CancellationToken cancellationToken)
  {
    var loan = await _libraryDbContext.Loans
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

    _libraryDbContext.Loans.Remove(loan);

    await _libraryDbContext.SaveChangesAsync(
        cancellationToken);

    return Result.Success();
  }
}

public class DeleteLoanCommandValidator
    : AbstractValidator<DeleteLoanCommand>
{
  public DeleteLoanCommandValidator()
  {
    RuleFor(x => x.Id)
        .GreaterThan(0)
        .WithMessage("Loan ID must be greater than 0.");
  }
}

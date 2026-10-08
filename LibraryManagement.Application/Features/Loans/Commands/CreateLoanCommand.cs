using FluentValidation;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Common.Results;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Loans.Commands.CreateLoan;

public class CreateLoanCommand : IRequest<Result<int>>
{
  public CreateLoanDto Loan { get; set; } = new();
}

public class CreateLoanCommandHandler
    : IRequestHandler<CreateLoanCommand, Result<int>>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public CreateLoanCommandHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<Result<int>> Handle(
      CreateLoanCommand request,
      CancellationToken cancellationToken)
  {
    var borrowerExists = await _libraryDbContext.Borrowers
        .AnyAsync(
            b => b.Id == request.Loan.BorrowerId,
            cancellationToken);

    if (!borrowerExists)
    {
      return Result<int>.Failure(
          new Error(
              "Borrower.NotFound",
              ErrorType.NotFound,
              $"Borrower with id {request.Loan.BorrowerId} was not found."));
    }

    var book = await _libraryDbContext.Books
        .FirstOrDefaultAsync(
            b => b.Id == request.Loan.BookId,
            cancellationToken);

    if (book is null)
    {
      return Result<int>.Failure(
          new Error(
              "Book.NotFound",
              ErrorType.NotFound,
              $"Book with id {request.Loan.BookId} was not found."));
    }

    if (!book.IsAvailable)
    {
      return Result<int>.Failure(
          new Error(
              "Book.NotAvailable",
              ErrorType.Conflict,
              $"Book with id {book.Id} is not available."));
    }

    var loan = new Loan
    {
      BorrowerId = request.Loan.BorrowerId,
      BookId = request.Loan.BookId,
      LoanDate = DateTime.UtcNow,
      ReturnDate = null,
      CreatedAt = DateTime.UtcNow,
      ModifiedAt = DateTime.UtcNow
    };

    book.IsAvailable = false;
    book.ModifiedAt = DateTime.UtcNow;

    await _libraryDbContext.Loans.AddAsync(
        loan,
        cancellationToken);

    await _libraryDbContext.SaveChangesAsync(
        cancellationToken);

    return Result<int>.Success(loan.Id);
  }
}

public class CreateLoanCommandValidator
    : AbstractValidator<CreateLoanCommand>
{
  public CreateLoanCommandValidator()
  {
    RuleFor(x => x.Loan)
        .NotNull()
        .WithMessage("Loan data is required.");

    RuleFor(x => x.Loan.BorrowerId)
        .GreaterThan(0)
        .WithMessage("Borrower ID must be greater than 0.");

    RuleFor(x => x.Loan.BookId)
        .GreaterThan(0)
        .WithMessage("Book ID must be greater than 0.");
  }
}

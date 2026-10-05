using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Features.Loans.Commands.CreateLoan;

public class CreateLoanCommand : IRequest<int>
{
  public int BorrowerId { get; set; }
  public int BookId { get; set; }
  public DateTime LoanDate { get; set; }
}

public class CreateLoanCommandHandler
    : IRequestHandler<CreateLoanCommand, int>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public CreateLoanCommandHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<int> Handle(
      CreateLoanCommand request,
      CancellationToken cancellationToken)
  {
    var loan = new Loan
    {
      BorrowerId = request.BorrowerId,
      BookId = request.BookId,
      LoanDate = request.LoanDate,
      CreatedAt = DateTime.UtcNow,
      ModifiedAt = DateTime.UtcNow
    };

    await _libraryDbContext.Loans.AddAsync(
        loan,
        cancellationToken);

    await _libraryDbContext.SaveChangesAsync(
        cancellationToken);

    return loan.Id;
  }
}

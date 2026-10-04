using LibraryManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Loans.Commands.UpdateLoan;

public class UpdateLoanCommand : IRequest<bool>
{
  public int Id { get; set; }
  public DateTime LoanDate { get; set; }
  public DateTime? ReturnDate { get; set; }
  public int BorrowerId { get; set; }
  public int BookId { get; set; }
}

public class UpdateLoanCommandHandler
    : IRequestHandler<UpdateLoanCommand, bool>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public UpdateLoanCommandHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<bool> Handle(
      UpdateLoanCommand request,
      CancellationToken cancellationToken)
  {
    var loan = await _libraryDbContext.Loans
        .FirstOrDefaultAsync(
            l => l.Id == request.Id,
            cancellationToken);

    if (loan is null)
      return false;

    loan.LoanDate = request.LoanDate;
    loan.ReturnDate = request.ReturnDate;
    loan.BorrowerId = request.BorrowerId;
    loan.BookId = request.BookId;
    loan.ModifiedAt = DateTime.UtcNow;

    await _libraryDbContext.SaveChangesAsync(
        cancellationToken);

    return true;
  }
}

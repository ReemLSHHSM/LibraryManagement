using LibraryManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Loans.Commands.DeleteLoan;

public class DeleteLoanCommand : IRequest<bool>
{
  public int Id { get; set; }
}

public class DeleteLoanCommandHandler
    : IRequestHandler<DeleteLoanCommand, bool>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public DeleteLoanCommandHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<bool> Handle(
      DeleteLoanCommand request,
      CancellationToken cancellationToken)
  {
    var loan = await _libraryDbContext.Loans
        .FirstOrDefaultAsync(
            l => l.Id == request.Id,
            cancellationToken);

    if (loan is null)
      return false;

    _libraryDbContext.Loans.Remove(loan);

    await _libraryDbContext.SaveChangesAsync(
        cancellationToken);

    return true;
  }
}

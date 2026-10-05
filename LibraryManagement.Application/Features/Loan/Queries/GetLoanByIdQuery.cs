using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Loans.Queries.GetLoanById;

public class GetLoanByIdQuery : IRequest<Loan?>
{
  public int Id { get; set; }
}

public class GetLoanByIdQueryHandler
    : IRequestHandler<GetLoanByIdQuery, Loan?>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public GetLoanByIdQueryHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<Loan?> Handle(
      GetLoanByIdQuery request,
      CancellationToken cancellationToken)
  {
    return await _libraryDbContext.Loans
        .FirstOrDefaultAsync(
            l => l.Id == request.Id,
            cancellationToken);
  }
}

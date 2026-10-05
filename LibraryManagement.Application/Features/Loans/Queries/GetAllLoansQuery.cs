using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Loans.Queries.GetAllLoans;

public class GetAllLoansQuery : IRequest<List<Loan>>
{
}

public class GetAllLoansQueryHandler
    : IRequestHandler<GetAllLoansQuery, List<Loan>>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public GetAllLoansQueryHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<List<Loan>> Handle(
      GetAllLoansQuery request,
      CancellationToken cancellationToken)
  {
    return await _libraryDbContext.Loans
        .ToListAsync(cancellationToken);
  }
}

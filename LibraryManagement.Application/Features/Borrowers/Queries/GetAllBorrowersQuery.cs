using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Features.Borrowers.Queries.GetAllBorrowers;

public class GetAllBorrowersQuery : IRequest<IEnumerable<Borrower>>
{
}

public class GetAllBorrowersQueryHandler
    : IRequestHandler<GetAllBorrowersQuery, IEnumerable<Borrower>>
{
  private readonly IGenericRepository<Borrower> _repository;

  public GetAllBorrowersQueryHandler(
      IGenericRepository<Borrower> repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<Borrower>> Handle(
      GetAllBorrowersQuery request,
      CancellationToken cancellationToken)
  {
    return await _repository.GetAllAsync(cancellationToken);
  }
}

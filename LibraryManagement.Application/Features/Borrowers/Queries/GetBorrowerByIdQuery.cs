using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Features.Borrowers.Queries.GetBorrowerById;

public class GetBorrowerByIdQuery : IRequest<Borrower?>
{
  public int Id { get; set; }
}

public class GetBorrowerByIdQueryHandler
    : IRequestHandler<GetBorrowerByIdQuery, Borrower?>
{
  private readonly IGenericRepository<Borrower> _repository;

  public GetBorrowerByIdQueryHandler(
      IGenericRepository<Borrower> repository)
  {
    _repository = repository;
  }

  public async Task<Borrower?> Handle(
      GetBorrowerByIdQuery request,
      CancellationToken cancellationToken)
  {
    return await _repository.GetByIdAsync(
        request.Id,
        cancellationToken);
  }
}

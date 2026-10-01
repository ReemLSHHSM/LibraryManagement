using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Features.Borrowers.Commands.DeleteBorrower;

public class DeleteBorrowerCommand : IRequest<bool>
{
  public int Id { get; set; }
}

public class DeleteBorrowerCommandHandler
    : IRequestHandler<DeleteBorrowerCommand, bool>
{
  private readonly IGenericRepository<Borrower> _repository;

  public DeleteBorrowerCommandHandler(
      IGenericRepository<Borrower> repository)
  {
    _repository = repository;
  }

  public async Task<bool> Handle(
      DeleteBorrowerCommand request,
      CancellationToken cancellationToken)
  {
    var borrower = await _repository.GetByIdAsync(
        request.Id,
        cancellationToken);

    if (borrower is null)
    {
      return false;
    }

    await _repository.DeleteAsync(
        borrower,
        cancellationToken);

    return true;
  }
}

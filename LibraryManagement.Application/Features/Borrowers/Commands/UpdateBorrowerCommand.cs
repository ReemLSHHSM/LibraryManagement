using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Features.Borrowers.Commands.UpdateBorrower;

public class UpdateBorrowerCommand : IRequest<bool>
{
  public int Id { get; set; }
  public string Phone { get; set; } = string.Empty;
}

public class UpdateBorrowerCommandHandler
    : IRequestHandler<UpdateBorrowerCommand, bool>
{
  private readonly IGenericRepository<Borrower> _repository;

  public UpdateBorrowerCommandHandler(
      IGenericRepository<Borrower> repository)
  {
    _repository = repository;
  }

  public async Task<bool> Handle(
      UpdateBorrowerCommand request,
      CancellationToken cancellationToken)
  {
    var borrower = await _repository.GetByIdAsync(
        request.Id,
        cancellationToken);

    if (borrower is null)
    {
      return false;
    }

    borrower.Phone = request.Phone;
    borrower.ModifiedAt = DateTime.UtcNow;

    await _repository.UpdateAsync(
        borrower,
        cancellationToken);

    return true;
  }
}

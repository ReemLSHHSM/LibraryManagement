using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Features.Borrowers.Commands.CreateBorrower;

public class CreateBorrowerCommand : IRequest<int>
{
  public string Phone { get; set; } = string.Empty;
  public int UserId { get; set; }
}

public class CreateBorrowerCommandHandler
    : IRequestHandler<CreateBorrowerCommand, int>
{
  private readonly IGenericRepository<Borrower> _repository;

  public CreateBorrowerCommandHandler(
      IGenericRepository<Borrower> repository)
  {
    _repository = repository;
  }

  public async Task<int> Handle(
      CreateBorrowerCommand request,
      CancellationToken cancellationToken)
  {
    var borrower = new Borrower
    {
      Phone = request.Phone,
      UserId = request.UserId,
      CreatedAt = DateTime.UtcNow,
      ModifiedAt = DateTime.UtcNow
    };

    await _repository.AddAsync(
        borrower,
        cancellationToken);

    return borrower.Id;
  }
}

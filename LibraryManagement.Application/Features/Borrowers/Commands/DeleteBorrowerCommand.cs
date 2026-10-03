using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Borrowers.Commands.DeleteBorrower;

public class DeleteBorrowerCommand : IRequest<bool>
{
  public int Id { get; set; }
}

public class DeleteBorrowerCommandHandler
    : IRequestHandler<DeleteBorrowerCommand, bool>
{
    private readonly ILibraryDbContext _libraryDbContext;

    public DeleteBorrowerCommandHandler(
      ILibraryDbContext libraryDbContext)
  {
        _libraryDbContext = libraryDbContext;
  }

  public async Task<bool> Handle(
      DeleteBorrowerCommand request,
      CancellationToken cancellationToken)
  {
    var borrower = await _libraryDbContext.Borrowers.FirstOrDefaultAsync(
        b => b.Id == request.Id,
        cancellationToken);

    if (borrower is null)
    {
      return false;
    }

    _libraryDbContext.Borrowers.Remove(borrower);
    await _libraryDbContext.SaveChangesAsync(cancellationToken);

    return true;
  }
}

using LibraryManagement.Application.Common.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Borrowers.Commands.UpdateBorrower;

public class UpdateBorrowerCommand : IRequest<bool>
{
  public int Id { get; set; }
  public string Phone { get; set; } = string.Empty;
}

public class UpdateBorrowerCommandHandler
    : IRequestHandler<UpdateBorrowerCommand, bool>
{
    private readonly ILibraryDbContext _libraryDbContext;

    public UpdateBorrowerCommandHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<bool> Handle(
      UpdateBorrowerCommand request,
      CancellationToken cancellationToken)
  {
    var borrower = await _libraryDbContext.Borrowers.FirstOrDefaultAsync(
        b => b.Id == request.Id,
        cancellationToken);

    if (borrower is null)
    {
      return false;
    }

    borrower.Phone = request.Phone;
    borrower.ModifiedAt = DateTime.UtcNow;

        await _libraryDbContext.Borrowers.FirstOrDefaultAsync(b=>b.Id== request.Id,
        cancellationToken);

        if (borrower is null)
        {
            return false;
        }

        borrower.Adapt(request);
        await _libraryDbContext.SaveChangesAsync(cancellationToken);
        return true;
  }
}

using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Features.Authors.Commands.DeleteAuthor;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteAuthorCommandHandler
    : IRequestHandler<DeleteAuthorCommand, bool>
{
  private readonly ILibraryDbContext _context;

  public DeleteAuthorCommandHandler(
      ILibraryDbContext context)
  {
    _context = context;
  }

  public async Task<bool> Handle(
      DeleteAuthorCommand request,
      CancellationToken cancellationToken)
  {
    var author = await _context.Authors
        .FirstOrDefaultAsync(
            a => a.Id == request.Id,
            cancellationToken);

    if (author is null)
    {
      return false;
    }

    _context.Authors.Remove(author);

    await _context.SaveChangesAsync(cancellationToken);

    return true;
  }
}

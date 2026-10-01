using LibraryManagement.Application.Common.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler
    : IRequestHandler<UpdateAuthorCommand, bool>
{
  private readonly ILibraryDbContext _context;

  public UpdateAuthorCommandHandler(
      ILibraryDbContext context)
  {
    _context = context;
  }

  public async Task<bool> Handle(
      UpdateAuthorCommand request,
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

    request.Adapt(author);

    author.ModifiedAt = DateTime.UtcNow;

    await _context.SaveChangesAsync(
        cancellationToken);

    return true;
  }
}

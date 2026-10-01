using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Features.Authors.Commands.CreateAuthor;
using LibraryManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace LibraryManagement.Application.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandHandler
    : IRequestHandler<CreateAuthorCommand, int>
{
  private readonly ILibraryDbContext _context;

  public CreateAuthorCommandHandler(
      ILibraryDbContext context)
  {
    _context = context;
  }

  public async Task<int> Handle(
      CreateAuthorCommand request,
      CancellationToken cancellationToken)
  {
    var author = request.Adapt<Author>();

    author.CreatedAt = DateTime.UtcNow;
    author.ModifiedAt = DateTime.UtcNow;

    await _context.Authors.AddAsync(
        author,
        cancellationToken);

    await _context.SaveChangesAsync(
        cancellationToken);

    return author.Id;
  }
}

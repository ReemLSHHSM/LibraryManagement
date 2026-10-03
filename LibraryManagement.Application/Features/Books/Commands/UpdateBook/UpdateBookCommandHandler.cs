using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler
    : IRequestHandler<UpdateBookCommand, bool>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public UpdateBookCommandHandler(ILibraryDbContext libraryDbContext)
  {
        _libraryDbContext = libraryDbContext;
  }

    public async Task<bool> Handle(
      UpdateBookCommand request,
      CancellationToken cancellationToken)
    {
        var book = await _libraryDbContext.Books
            .FirstOrDefaultAsync(
                b => b.Id == request.Id,
                cancellationToken);

        if (book is null)
            return false;

        request.Adapt(book);

        book.ModifiedAt = DateTime.UtcNow;

        await _libraryDbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}

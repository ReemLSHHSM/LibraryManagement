using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Books.Commands.DeleteBookCommand;

public class DeleteBookCommandHandler
    : IRequestHandler<DeleteBookCommand, Result>
{
    private readonly ILibraryDbContext _libraryDbContext;

    public DeleteBookCommandHandler(
        ILibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Result> Handle(
        DeleteBookCommand request,
        CancellationToken cancellationToken)
    {
        var book = await _libraryDbContext.Books
            .FirstOrDefaultAsync(
                b => b.Id == request.Id,
                cancellationToken);

        if (book is null)
        {
            return Result.Failure(BookErrors.NotFound);
        }

        _libraryDbContext.Books.Remove(book);

        await _libraryDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
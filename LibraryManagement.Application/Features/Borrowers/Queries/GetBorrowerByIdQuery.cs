using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Borrowers.Queries.GetBorrowerById;

public class GetBorrowerByIdQuery : IRequest<Borrower?>
{
    public int Id { get; set; }
}

public class GetBorrowerByIdQueryHandler
    : IRequestHandler<GetBorrowerByIdQuery, Borrower?>
{
    private readonly ILibraryDbContext _libraryDbContext;

    public GetBorrowerByIdQueryHandler(
        ILibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Borrower?> Handle(
        GetBorrowerByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _libraryDbContext.Borrowers
            .FirstOrDefaultAsync(
                b => b.Id == request.Id,
                cancellationToken);
    }
}
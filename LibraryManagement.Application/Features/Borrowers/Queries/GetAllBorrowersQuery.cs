using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Borrowers.Queries.GetAllBorrowers;

public class GetAllBorrowersQuery : IRequest<IEnumerable<Borrower>>
{
}

public class GetAllBorrowersQueryHandler
    : IRequestHandler<GetAllBorrowersQuery, IEnumerable<Borrower>>
{
    private readonly ILibraryDbContext _libraryDbContext;

    public GetAllBorrowersQueryHandler(
        ILibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<IEnumerable<Borrower>> Handle(
        GetAllBorrowersQuery request,
        CancellationToken cancellationToken)
    {
        return await _libraryDbContext.Borrowers
            .ToListAsync(cancellationToken);
    }
}
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Common.Interfaces;

public interface IAuthorRepository
{
    Task AddAsync(
        Author author,
        CancellationToken cancellationToken);
}
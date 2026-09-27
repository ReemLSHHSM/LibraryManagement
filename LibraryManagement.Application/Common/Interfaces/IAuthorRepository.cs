using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Common.Interfaces;

public interface IAuthorRepository
{
    Task AddAsync(
        Author author,
        CancellationToken cancellationToken);

  Task<List<Author>> GetAuthorsAsync(
    CancellationToken cancellationToken);

  Task<Author> GetAuthorByIdAsync(
    int id,
    CancellationToken cancellationToken);

  Task <bool> UpdateAuthorAsync(
    Author author,
    CancellationToken cancellationToken);
}

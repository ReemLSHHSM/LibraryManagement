using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Common.Interfaces
{
  public interface ILibraryDbContext
  {
    DbSet<Author> Authors { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
  }
}

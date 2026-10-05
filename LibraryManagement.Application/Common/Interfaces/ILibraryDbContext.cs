using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Common.Interfaces
{
  public interface ILibraryDbContext
  {
    DbSet<Author> Authors { get; }

    DbSet<Book> Books { get; }

    DbSet<Borrower> Borrowers { get; }

    DbSet<Loan> Loans { get; }

    Task<int> SaveChangesAsync(
    CancellationToken cancellationToken = default);
  }
}

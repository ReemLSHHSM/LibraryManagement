using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Data;

public class LibraryDbContext : DbContext, ILibraryDbContext
{
  public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
      : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
  public DbSet<Borrower> Borrowers { get; set; }
  public DbSet<Author> Authors { get; set; }
  public DbSet<Book> Books { get; set; }
  public DbSet<Loan> Loans { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(
        typeof(LibraryDbContext).Assembly
    );
  }
}

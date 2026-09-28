using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Data;

public class LibraryDbContext : DbContext
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

    // User -> Borrower
    modelBuilder.Entity<User>()
        .HasOne(u => u.Borrower)
        .WithOne(b => b.User)
        .HasForeignKey<Borrower>(b => b.UserId)
        .OnDelete(DeleteBehavior.Cascade);


    // Author -> Books
    modelBuilder.Entity<Author>()
        .HasMany(a => a.Books)
        .WithOne(b => b.Author)
        .HasForeignKey(b => b.AuthorId)
        .OnDelete(DeleteBehavior.Cascade);


    // Borrower -> Loans
    modelBuilder.Entity<Borrower>()
        .HasMany(b => b.Loans)
        .WithOne(l => l.Borrower)
        .HasForeignKey(l => l.BorrowerId)
        .OnDelete(DeleteBehavior.Cascade);


    // Book -> Loans
    modelBuilder.Entity<Book>()
        .HasMany(b => b.Loans)
        .WithOne(l => l.Book)
        .HasForeignKey(l => l.BookId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}

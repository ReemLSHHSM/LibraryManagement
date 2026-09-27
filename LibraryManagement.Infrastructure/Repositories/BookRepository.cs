using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Infrastructure.Repositories
{
  public class BookRepository : IBookRepository
  {
    private readonly LibraryDbContext _context;

    public BookRepository(LibraryDbContext context)
    {
      _context = context;
    }


    public async Task<int> CreateBookAsync(Book book, CancellationToken cancellationToken)
    {
     await _context.Books.AddAsync(book, cancellationToken);
      return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Book>> GetBooksAsync(
    CancellationToken cancellationToken)
    {
      return await _context.Books
          .ToListAsync(cancellationToken);
    }

    public async Task<Book?> GetBookByIdAsync(
    int id,
    CancellationToken cancellationToken)
    {
      return await _context.Books
          .FirstOrDefaultAsync(
              b => b.Id == id,
              cancellationToken);
    }

    public async Task<bool> UpdateBookAsync(
    Book book,
    CancellationToken cancellationToken)
    {
      var existingBook = await _context.Books.FindAsync(
          new object[] { book.Id },
          cancellationToken);

      if (existingBook == null)
        return false;

      existingBook.Title = book.Title;
      existingBook.ISBN = book.ISBN;
      existingBook.PublishedDate = book.PublishedDate;
      existingBook.AuthorId = book.AuthorId;
      existingBook.IsAvailable = book.IsAvailable;
      existingBook.ModifiedAt = DateTime.UtcNow;

      await _context.SaveChangesAsync(cancellationToken);

      return true;
    }

    public async Task<bool> DeleteBookAsync(
    int id,
    CancellationToken cancellationToken)
    {
      var book = await _context.Books.FindAsync(
          new object[] { id },
          cancellationToken);

      if (book == null)
        return false;

      _context.Books.Remove(book);
      await _context.SaveChangesAsync(cancellationToken);

      return true;
    }

  }
}

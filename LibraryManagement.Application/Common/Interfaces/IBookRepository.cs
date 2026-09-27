using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Common.Interfaces
{
  public interface IBookRepository
  {

     Task<int> CreateBookAsync(Book book, CancellationToken cancellationToken);
    Task<List<Book>> GetBooksAsync(
    CancellationToken cancellationToken);

    Task<Book?> GetBookByIdAsync(
    int id,
    CancellationToken cancellationToken);

    Task<bool> UpdateBookAsync(
    Book book,
    CancellationToken cancellationToken);

    Task<bool> DeleteBookAsync(
    int id,
    CancellationToken cancellationToken);
  }
}

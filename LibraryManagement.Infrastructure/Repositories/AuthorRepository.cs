using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDbContext _context;

    public AuthorRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Author author,
        CancellationToken cancellationToken)
    {
        await _context.Authors.AddAsync(author, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

  public async Task<List<Author>> GetAuthorsAsync(CancellationToken cancellationToken)
     {

    return await _context.Authors.ToListAsync(cancellationToken);

  }

  public async Task<Author> GetAuthorByIdAsync(int id, CancellationToken cancellationToken)
  {
    return await _context.Authors.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
  }

  public async Task<bool> UpdateAuthorAsync(Author author, CancellationToken cancellationToken)
  {
    var existingAuthor = await _context.Authors.FindAsync(new object[] { author.Id }, cancellationToken);
    if (existingAuthor == null)
    {
      return false;
    }
    existingAuthor.Name = author.Name;
    existingAuthor.Bio = author.Bio;
    existingAuthor.ModifiedAt = DateTime.UtcNow;
    _context.Authors.Update(existingAuthor);
    await _context.SaveChangesAsync(cancellationToken);
    return true;
  }
}

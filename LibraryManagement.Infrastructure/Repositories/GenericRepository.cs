using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
  private readonly LibraryDbContext _context;

  public GenericRepository(LibraryDbContext context)
  {
    _context = context;
  }

  public async Task<T?> GetByIdAsync(
      int id,
      CancellationToken cancellationToken = default)
  {
    return await _context.Set<T>()
        .FindAsync([id], cancellationToken);
  }

  public async Task<IEnumerable<T>> GetAllAsync(
      CancellationToken cancellationToken = default)
  {
    return await _context.Set<T>()
        .ToListAsync(cancellationToken);
  }

  public async Task AddAsync(
      T entity,
      CancellationToken cancellationToken = default)
  {
    await _context.Set<T>()
        .AddAsync(entity, cancellationToken);

    await _context.SaveChangesAsync(cancellationToken);
  }

  public async Task UpdateAsync(
      T entity,
      CancellationToken cancellationToken = default)
  {
    _context.Set<T>().Update(entity);

    await _context.SaveChangesAsync(cancellationToken);
  }

  public async Task DeleteAsync(
      T entity,
      CancellationToken cancellationToken = default)
  {
    _context.Set<T>().Remove(entity);

    await _context.SaveChangesAsync(cancellationToken);
  }
}

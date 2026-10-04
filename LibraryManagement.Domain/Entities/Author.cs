using LibraryManagement.Domain.Common;

namespace LibraryManagement.Domain.Entities;

public class Author : BaseEntity
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string? Bio { get; set; }

  public ICollection<Book> Books { get; set; } = new List<Book>();
  public DateTime CreatedAt { get; set; }
  public DateTime ModifiedAt { get; set; }
}

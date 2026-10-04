using LibraryManagement.Domain.Common;

namespace LibraryManagement.Domain.Entities;

public class Book : BaseEntity
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string ISBN { get; set; } = string.Empty;
  public DateTime PublishedDate { get; set; }

  public bool IsAvailable { get; set; } = true;

  //Relations
  public int AuthorId { get; set; }
  public Author Author { get; set; } = null!;
  public ICollection<Loan> Loans { get; set; } = new List<Loan>();


  public DateTime CreatedAt { get; set; }
  public DateTime ModifiedAt { get; set; }
}

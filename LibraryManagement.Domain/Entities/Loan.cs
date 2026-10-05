using LibraryManagement.Domain.Common;

namespace LibraryManagement.Domain.Entities;

public class Loan : BaseEntity
{
  public int Id { get; set; }

  public DateTime LoanDate { get; set; }
  public DateTime? ReturnDate { get; set; }

  public int BorrowerId { get; set; }
  public int BookId { get; set; }
  public Borrower Borrower { get; set; } = null!;
  public Book Book { get; set; } = null!;

  public DateTime CreatedAt { get; set; }
  public DateTime ModifiedAt { get; set; }
}

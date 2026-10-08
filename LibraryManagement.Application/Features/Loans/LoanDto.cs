namespace LibraryManagement.Application.Features.Loans;

public class LoanDto
{
  public int Id { get; set; }

  public DateTime LoanDate { get; set; }
  public DateTime? ReturnDate { get; set; }

  public int BorrowerId { get; set; }
  public int BookId { get; set; }
}

public class CreateLoanDto
{
  public int BorrowerId { get; set; }
  public int BookId { get; set; }
}

public class ReturnLoanDto
{
  public int Id { get; set; }
}

namespace LibraryManagement.Application.Features.Borrowers
{
  public class BorrowerDto
  {
    public int Id { get; set; }

    public string Phone { get; set; } = string.Empty;

    public int UserId { get; set; }
  }

  public class CreateBorrowerDto
  {
    public string Phone { get; set; } = string.Empty;

    public int UserId { get; set; }
  }

  public class UpdateBorrowerDto
  {
    public string Phone { get; set; } = string.Empty;

    public int UserId { get; set; }
  }
}



namespace LibraryManagement.Application.Common.Dtos
{
  public class ExternalBookDto
  {
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string? Author { get; set; }

    public string? Category { get; set; }

    public int? PublishedYear { get; set; }

    public string? CoverImage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
  }

  public class ExternalBooksResponseDto
  {
    public List<ExternalBookDto> Books { get; set; } = new();
  }

  public class CreateExternalBookDto
  {
    public string Title { get; set; } = string.Empty;

    public string? Author { get; set; }

    public string? Category { get; set; }

    public int? PublishedYear { get; set; }
  }

}

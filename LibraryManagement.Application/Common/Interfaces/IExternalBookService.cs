using LibraryManagement.Application.Common.Dtos;

namespace LibraryManagement.Application.Common.Interfaces
{
  public interface IExternalBookService
  {
    Task<List<ExternalBookDto>> GetBooksAsync(CancellationToken cancellationToken = default);

    Task CreateBookAsync(CreateExternalBookDto bookDto, CancellationToken cancellationToken = default);
  }
}

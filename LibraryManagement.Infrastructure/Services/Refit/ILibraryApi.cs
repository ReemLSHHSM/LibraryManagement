using LibraryManagement.Application.Common.Dtos;
using Refit;

namespace LibraryManagement.Infrastructure.ExternalApis;

public interface ILibraryApi
{
  [Get("/api/books")]
  Task<ExternalBooksResponseDto> GetAllBooksAsync(
      CancellationToken cancellationToken = default);

  [Post("/api/books")]
  Task CreateBookAsync(
      [Body] CreateExternalBookDto book,
      CancellationToken cancellationToken = default);
}

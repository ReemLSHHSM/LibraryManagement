using LibraryManagement.Application.Common.Dtos;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Infrastructure.ExternalApis;

namespace LibraryManagement.Infrastructure.Services;

public class RefitExternalBookService : IExternalBookService
{
  private readonly ILibraryApi _libraryApi;

  public RefitExternalBookService(ILibraryApi libraryApi)
  {
    _libraryApi = libraryApi;
  }

  public async Task<List<ExternalBookDto>> GetBooksAsync(
      CancellationToken cancellationToken = default)
  {
    var response =
        await _libraryApi.GetAllBooksAsync(cancellationToken);

    return response.Books;
  }

  public async Task CreateBookAsync(
      CreateExternalBookDto book,
      CancellationToken cancellationToken = default)
  {
    await _libraryApi.CreateBookAsync(
        book,
        cancellationToken);
  }
}

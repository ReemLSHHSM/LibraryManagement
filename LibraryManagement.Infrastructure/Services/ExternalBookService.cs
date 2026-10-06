using LibraryManagement.Application.Common.Dtos;
using LibraryManagement.Application.Common.Interfaces;
using System.Net.Http.Json;


namespace LibraryManagement.Infrastructure.Services
{
  public class ExternalBookService : IExternalBookService
  {
    private readonly HttpClient _httpClient;

    public ExternalBookService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }


    public async Task CreateBookAsync(
    CreateExternalBookDto bookDto,
    CancellationToken cancellationToken = default)
    {
      var response = await _httpClient.PostAsJsonAsync(
          "api/books",
          bookDto,
          cancellationToken);

      response.EnsureSuccessStatusCode();
    }

    public async Task<List<ExternalBookDto>> GetBooksAsync(
       CancellationToken cancellationToken = default)
    {
      var response = await _httpClient.GetAsync(
          "api/books",
          cancellationToken);

      response.EnsureSuccessStatusCode();

      var rawJson = await response.Content
    .ReadFromJsonAsync<ExternalBooksResponseDto>(
        cancellationToken: cancellationToken);

      var books = rawJson?.Books ?? new List<ExternalBookDto>();

      return books;
    }
  }
}

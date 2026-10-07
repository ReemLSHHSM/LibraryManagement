using LibraryManagement.Application.Common.Dtos;
using LibraryManagement.Application.Common.Interfaces;
using System.Net.Http.Json;

namespace LibraryManagement.Infrastructure.Services
{
  public class ExternalAuthService : IExternalAuthService
  {
    private readonly HttpClient _httpClient;
    private readonly ITokenProvider _tokenProvider;

    public ExternalAuthService(
        IHttpClientFactory httpClientFactory,
        ITokenProvider tokenProvider)
    {
      _httpClient = httpClientFactory.CreateClient("LibraryApi");
      _tokenProvider = tokenProvider;
    }

    public async Task LoginAsync(
    ExternalLoginDto loginDto,
    CancellationToken cancellationToken = default)
    {
      var response = await _httpClient.PostAsJsonAsync(
          "api/users/login",
          loginDto,
          cancellationToken);

      response.EnsureSuccessStatusCode();

      var result = await response.Content
          .ReadFromJsonAsync<ExternalLoginResponseDto>(
              cancellationToken: cancellationToken);

      _tokenProvider.Token = result?.Token;
    }

    public async Task RegisterAsync(
    ExternalRegisterDto registerDto,
    CancellationToken cancellationToken = default)
    {
      var response = await _httpClient.PostAsJsonAsync(
          "api/users/register",
          registerDto,
          cancellationToken);

      response.EnsureSuccessStatusCode();
    }
  }
}

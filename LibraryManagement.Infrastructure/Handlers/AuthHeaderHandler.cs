using LibraryManagement.Application.Common.Interfaces;
using System.Net.Http.Headers;

namespace LibraryManagement.Infrastructure.Handlers
{
  public class AuthHeaderHandler : DelegatingHandler
  {
    private readonly ITokenProvider _tokenProvider;

    public AuthHeaderHandler(ITokenProvider tokenProvider)
    {
      _tokenProvider = tokenProvider;
    }


    protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
    {
      var token = _tokenProvider.Token;

      if (!string.IsNullOrWhiteSpace(token))
      {
        request.Headers.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                token);
      }

      return await base.SendAsync(
          request,
          cancellationToken);
    }


  }
}

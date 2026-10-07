using LibraryManagement.Application.Common.Interfaces;

namespace LibraryManagement.Infrastructure.Services
{
  public class TokenProvider : ITokenProvider
  {
    public string? Token { get; set; }
  }
}

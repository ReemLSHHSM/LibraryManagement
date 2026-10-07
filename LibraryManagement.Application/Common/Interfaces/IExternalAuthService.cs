using LibraryManagement.Application.Common.Dtos;

namespace LibraryManagement.Application.Common.Interfaces
{
  public interface IExternalAuthService
  {
    Task LoginAsync(
        ExternalLoginDto loginDto,
        CancellationToken cancellationToken = default);

    Task RegisterAsync(
    ExternalRegisterDto registerDto,
    CancellationToken cancellationToken = default);
  }

}

using LibraryManagement.Application.Common.Dtos;
using LibraryManagement.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ExternalAuthController : ControllerBase
  {
    private readonly IExternalAuthService _externalAuthService;

    public ExternalAuthController(
        IExternalAuthService externalAuthService)
    {
      _externalAuthService = externalAuthService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        ExternalRegisterDto registerDto,
        CancellationToken cancellationToken)
    {
      await _externalAuthService.RegisterAsync(
          registerDto,
          cancellationToken);

      return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        ExternalLoginDto loginDto,
        CancellationToken cancellationToken)
    {
      await _externalAuthService.LoginAsync(
          loginDto,
          cancellationToken);

      return Ok();
    }
  }
}

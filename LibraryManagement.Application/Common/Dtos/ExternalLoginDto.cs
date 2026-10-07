namespace LibraryManagement.Application.Common.Dtos
{
  public class ExternalLoginDto
  {
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
  }
  public class ExternalLoginResponseDto
  {
    public string Token { get; set; } = string.Empty;
  }
}

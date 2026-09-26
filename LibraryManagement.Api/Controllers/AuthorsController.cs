using LibraryManagement.Application.Authors.Commands.CreateAuthor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly ISender _sender;

    public AuthorsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        CreateAuthorCommand command,
        CancellationToken cancellationToken)
    {
        var authorId = await _sender.Send(command, cancellationToken);

        return Ok(authorId);
    }
}
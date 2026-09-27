using LibraryManagement.Application.Authors;
using LibraryManagement.Application.Authors.Commands.CreateAuthor;
using LibraryManagement.Application.Authors.Queries.GetAuthors;
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

    [HttpGet]
    public async Task<ActionResult<List<AuthorDto>>> GetAuthors(
        CancellationToken cancellationToken)
    {
        var query = new GetAuthorsQuery();
        var authors = await _sender.Send(query, cancellationToken);
        return Ok(authors);
    }
}

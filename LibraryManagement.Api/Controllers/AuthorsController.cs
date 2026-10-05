using LibraryManagement.Api.Filters;
using LibraryManagement.Application.Features.Authors;
using LibraryManagement.Application.Features.Authors.Commands.CreateAuthor;
using LibraryManagement.Application.Features.Authors.Commands.DeleteAuthor;
using LibraryManagement.Application.Features.Authors.Commands.UpdateAuthor;
using LibraryManagement.Application.Features.Authors.Queries.GetAuthor;
using LibraryManagement.Application.Features.Authors.Queries.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ServiceFilter(typeof(RequestLoggingFilter))]
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

  [HttpGet("{id}")]
  public async Task<ActionResult<AuthorDto>> GetAuthorByIdAsync(
    [FromRoute] int id,
    CancellationToken cancellationToken)
  {
    var query = new GetAuthorByIdAsync(id);
    var author = await _sender.Send(query, cancellationToken);
    if (author == null)
    {
      return NotFound();
    }
    return Ok(author);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateAuthorAsync(
     [FromRoute] int id,
     [FromBody] UpdateAuthorCommand command,
     CancellationToken cancellationToken)
  {
    if (id != command.Id)
    {
      return BadRequest();
    }

    var updated = await _sender.Send(command, cancellationToken);

    if (!updated)
    {
      return NotFound();
    }

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteAuthorAsync(
    [FromRoute] int id,
    CancellationToken cancellationToken)
  {
    var deleted = await _sender.Send(new DeleteAuthorCommand(id), cancellationToken);

    if (!deleted)
    {
      return NotFound();
    }

    return NoContent();
  }

}


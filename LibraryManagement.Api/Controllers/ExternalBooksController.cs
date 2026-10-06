using LibraryManagement.Application.Features.ExternalBooks.Commands;
using LibraryManagement.Application.Features.ExternalBooks.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ExternalBooksController : ControllerBase
  {
    private readonly ISender _sender;

    public ExternalBooksController(ISender sender)
    {
      _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
     CancellationToken cancellationToken)
    {
      var books = await _sender.Send(
          new GetAllExternalBooksQueryRequest(),
          cancellationToken);

      return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> AddExternalBook(
    [FromBody] CreateExternalBookCommand command,
    CancellationToken cancellationToken)
    {
      await _sender.Send(command, cancellationToken);

      return Ok();
    }

  }
}

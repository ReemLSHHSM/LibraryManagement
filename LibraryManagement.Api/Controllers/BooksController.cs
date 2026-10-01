using LibraryManagement.Application.Features.Books;
using LibraryManagement.Application.Features.Books.Commands.CreateBook;
using LibraryManagement.Application.Features.Books.Commands.DeleteBookCommand;
using LibraryManagement.Application.Features.Books.Commands.UpdateBook;
using LibraryManagement.Application.Features.Books.Queries.GetBookById;
using LibraryManagement.Application.Features.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController: ControllerBase
  {
    private readonly ISender _sender;

    public BooksController(ISender sender)
    {
      _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        CreateBookCommand command,
        CancellationToken cancellationToken)
    {
      var bookId = await _sender.Send(command, cancellationToken);
      return Ok(bookId);
    }

    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> GetBooks(
    CancellationToken cancellationToken)
    {
      var books = await _sender.Send(
          new GetBooksQuery(),
          cancellationToken);

      return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBookById(
    [FromRoute] int id,
    CancellationToken cancellationToken)
    {
      var book = await _sender.Send(
          new GetBookByIdQuery(id),
          cancellationToken);

      if (book == null)
        return NotFound();

      return Ok(book);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBook(
    [FromRoute] int id,
    [FromBody] UpdateBookCommand command,
    CancellationToken cancellationToken)
    {
      if (id != command.Id)
        return BadRequest();

      var updated = await _sender.Send(command, cancellationToken);

      if (!updated)
        return NotFound();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(
    [FromRoute] int id,
    CancellationToken cancellationToken)
    {
      var deleted = await _sender.Send(
          new DeleteBookCommand(id),
          cancellationToken);

      if (!deleted)
        return NotFound();

      return NoContent();
    }
  }
}

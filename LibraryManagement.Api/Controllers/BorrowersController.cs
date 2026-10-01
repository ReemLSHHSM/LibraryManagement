using LibraryManagement.Application.Features.Borrowers.Commands.CreateBorrower;
using LibraryManagement.Application.Features.Borrowers.Commands.DeleteBorrower;
using LibraryManagement.Application.Features.Borrowers.Commands.UpdateBorrower;
using LibraryManagement.Application.Features.Borrowers.Queries.GetAllBorrowers;
using LibraryManagement.Application.Features.Borrowers.Queries.GetBorrowerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowersController : ControllerBase
{
  private readonly ISender _sender;

  public BorrowersController(ISender sender)
  {
    _sender = sender;
  }

  [HttpPost]
  public async Task<IActionResult> Create(
      CreateBorrowerCommand command,
      CancellationToken cancellationToken)
  {
    var id = await _sender.Send(command, cancellationToken);

    return Ok(id);
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById(
      int id,
      CancellationToken cancellationToken)
  {
    var borrower = await _sender.Send(
        new GetBorrowerByIdQuery { Id = id },
        cancellationToken);

    if (borrower is null)
    {
      return NotFound();
    }

    return Ok(borrower);
  }

  [HttpGet]
  public async Task<IActionResult> GetAll(
      CancellationToken cancellationToken)
  {
    var borrowers = await _sender.Send(
        new GetAllBorrowersQuery(),
        cancellationToken);

    return Ok(borrowers);
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(
      int id,
      UpdateBorrowerCommand command,
      CancellationToken cancellationToken)
  {
    command.Id = id;

    var updated = await _sender.Send(
        command,
        cancellationToken);

    if (!updated)
    {
      return NotFound();
    }

    return NoContent();
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(
      int id,
      CancellationToken cancellationToken)
  {
    var deleted = await _sender.Send(
        new DeleteBorrowerCommand { Id = id },
        cancellationToken);

    if (!deleted)
    {
      return NotFound();
    }

    return NoContent();
  }
}

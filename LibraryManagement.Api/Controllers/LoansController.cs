using LibraryManagement.Application.Features.Loans.Commands.CreateLoan;
using LibraryManagement.Application.Features.Loans.Commands.DeleteLoan;
using LibraryManagement.Application.Features.Loans.Commands.UpdateLoan;
using LibraryManagement.Application.Features.Loans.Queries.GetAllLoans;
using LibraryManagement.Application.Features.Loans.Queries.GetLoanById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
  private readonly ISender _sender;

  public LoansController(ISender sender)
  {
    _sender = sender;
  }

  [HttpPost]
  public async Task<IActionResult> CreateLoan(
      CreateLoanCommand command,
      CancellationToken cancellationToken)
  {
    var id = await _sender.Send(command, cancellationToken);

    return Ok(id);
  }

  [HttpGet]
  public async Task<IActionResult> GetAllLoans(
      CancellationToken cancellationToken)
  {
    var loans = await _sender.Send(
        new GetAllLoansQuery(),
        cancellationToken);

    return Ok(loans);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetLoanById(
      int id,
      CancellationToken cancellationToken)
  {
    var loan = await _sender.Send(
        new GetLoanByIdQuery
        {
          Id = id
        },
        cancellationToken);

    if (loan is null)
      return NotFound();

    return Ok(loan);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateLoan(
      int id,
      UpdateLoanCommand command,
      CancellationToken cancellationToken)
  {
    command.Id = id;

    var updated = await _sender.Send(
        command,
        cancellationToken);

    if (!updated)
      return NotFound();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteLoan(
      int id,
      CancellationToken cancellationToken)
  {
    var deleted = await _sender.Send(
        new DeleteLoanCommand
        {
          Id = id
        },
        cancellationToken);

    if (!deleted)
      return NotFound();

    return NoContent();
  }
}

using FluentValidation;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Features.Borrowers.Commands.DeleteBorrower;

public class DeleteBorrowerCommand : IRequest<Result>
{
  public int Id { get; set; }
}

public class DeleteBorrowerCommandHandler
    : IRequestHandler<DeleteBorrowerCommand, Result>
{
  private readonly ILibraryDbContext _libraryDbContext;

  public DeleteBorrowerCommandHandler(
      ILibraryDbContext libraryDbContext)
  {
    _libraryDbContext = libraryDbContext;
  }

  public async Task<Result> Handle(
      DeleteBorrowerCommand request,
      CancellationToken cancellationToken)
  {
    var borrower = await _libraryDbContext.Borrowers
        .FirstOrDefaultAsync(
            b => b.Id == request.Id,
            cancellationToken);

    if (borrower is null)
    {
      return Result.Failure(
          new Error(
              "Borrower.NotFound",
              ErrorType.NotFound,
              $"Borrower with id {request.Id} was not found."));
    }

    _libraryDbContext.Borrowers.Remove(borrower);

    await _libraryDbContext.SaveChangesAsync(
        cancellationToken);

    return Result.Success();
  }
}

public class DeleteBorrowerCommandValidator
    : AbstractValidator<DeleteBorrowerCommand>
{
  public DeleteBorrowerCommandValidator()
  {
    RuleFor(x => x.Id)
        .GreaterThan(0)
        .WithMessage("Borrower ID must be greater than 0.");
  }
}

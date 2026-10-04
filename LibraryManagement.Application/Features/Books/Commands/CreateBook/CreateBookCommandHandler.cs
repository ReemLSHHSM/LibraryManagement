using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands.CreateBook
{
  public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
  {

    private readonly ILibraryDbContext _libraryDbContext;

    public CreateBookCommandHandler(ILibraryDbContext libraryDbContext)
    {
      _libraryDbContext = libraryDbContext;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
      var book = request.Adapt<Book>();
      await _libraryDbContext.Books.AddAsync(book, cancellationToken);
      await _libraryDbContext.SaveChangesAsync(cancellationToken);
      return book.Id;
    }
  }
}

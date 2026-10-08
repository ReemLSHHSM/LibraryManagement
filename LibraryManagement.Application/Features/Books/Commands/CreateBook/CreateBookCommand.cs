using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands.CreateBook
{
  public record CreateBookCommand(
   CreateBookDto CreateBookDto
) : IRequest<int>;

}

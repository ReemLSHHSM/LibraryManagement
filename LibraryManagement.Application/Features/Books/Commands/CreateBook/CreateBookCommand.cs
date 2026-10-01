using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Features.Books.Commands.CreateBook
{
  public record CreateBookCommand(
    string Title,
    string ISBN,
    DateTime PublishedDate,
    int AuthorId
) : IRequest<int>;

}

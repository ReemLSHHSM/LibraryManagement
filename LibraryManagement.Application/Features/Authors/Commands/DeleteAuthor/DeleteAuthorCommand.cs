using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Features.Authors.Commands.DeleteAuthor
{
  public record DeleteAuthorCommand(int Id) : IRequest<bool>;

}

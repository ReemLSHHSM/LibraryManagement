using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Authors.Commands.DeleteAuthor
{
  public record DeleteAuthorCommand(int Id) : IRequest<bool>;

}

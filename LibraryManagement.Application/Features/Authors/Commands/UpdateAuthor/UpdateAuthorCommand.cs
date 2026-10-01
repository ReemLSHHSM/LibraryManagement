using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Features.Authors.Commands.UpdateAuthor
{
  public record UpdateAuthorCommand(
    int Id,
    string Name,
    string? Bio
) : IRequest<bool>;
}

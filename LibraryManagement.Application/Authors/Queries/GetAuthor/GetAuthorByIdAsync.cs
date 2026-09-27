using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Authors.Queries.GetAuthor
{
  public record GetAuthorByIdAsync(int id) : IRequest<AuthorDto>;
  
}

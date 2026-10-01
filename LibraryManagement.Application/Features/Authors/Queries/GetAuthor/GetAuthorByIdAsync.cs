using LibraryManagement.Application.Features.Authors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Features.Authors.Queries.GetAuthor
{
  public record GetAuthorByIdAsync(int id) : IRequest<AuthorDto>;
  
}

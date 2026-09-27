using LibraryManagement.Application.Common.Interfaces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Authors.Queries.GetAuthor
{
  public class GetAuthorByIdAsyncHandler:IRequestHandler<GetAuthorByIdAsync, AuthorDto>
  {
    private readonly IAuthorRepository _authorRepository;
    public GetAuthorByIdAsyncHandler(IAuthorRepository authorRepository)
    {
      _authorRepository = authorRepository;
    }
    public async Task<AuthorDto> Handle(GetAuthorByIdAsync request, CancellationToken cancellationToken)
    {
      var author = await _authorRepository.GetAuthorByIdAsync(request.id, cancellationToken);
      return author.Adapt<AuthorDto>();
    }
  


  }
}

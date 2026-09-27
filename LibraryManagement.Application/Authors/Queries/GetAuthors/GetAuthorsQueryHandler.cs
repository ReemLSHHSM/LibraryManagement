using LibraryManagement.Application.Common.Interfaces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Authors.Queries.GetAuthors
{
  public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<AuthorDto>>
  {

    private readonly IAuthorRepository _authorRepository;

    public GetAuthorsQueryHandler(IAuthorRepository authorRepository)
    {
      _authorRepository = authorRepository;
    }
    public async Task<List<AuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
      var authers = await _authorRepository.GetAuthorsAsync(cancellationToken);

      return authers.Adapt<List<AuthorDto>>();
    }
  }
}

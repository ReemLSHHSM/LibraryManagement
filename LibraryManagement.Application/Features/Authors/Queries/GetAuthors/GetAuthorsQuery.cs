using LibraryManagement.Application.Features.Authors;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Queries.GetAuthors;

public record GetAuthorsQuery
    : IRequest<List<AuthorDto>>;

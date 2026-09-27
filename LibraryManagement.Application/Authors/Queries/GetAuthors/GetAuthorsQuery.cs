using MediatR;

namespace LibraryManagement.Application.Authors.Queries.GetAuthors;

public record GetAuthorsQuery
    : IRequest<List<AuthorDto>>;

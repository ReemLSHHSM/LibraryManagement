using MediatR;

namespace LibraryManagement.Application.Authors.Commands.CreateAuthor;

public record CreateAuthorCommand(
    string Name,
    string? Bio
) : IRequest<int>;
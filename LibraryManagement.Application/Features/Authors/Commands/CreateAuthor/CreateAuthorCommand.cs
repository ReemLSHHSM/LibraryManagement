using MediatR;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthor;

public record CreateAuthorCommand(
    string Name,
    string? Bio
) : IRequest<int>;
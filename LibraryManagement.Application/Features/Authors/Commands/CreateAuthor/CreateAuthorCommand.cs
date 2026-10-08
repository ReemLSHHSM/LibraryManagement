using MediatR;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthor;

public record CreateAuthorCommand(CreateAuthorDto CreateAuthorDto
) : IRequest<int>;

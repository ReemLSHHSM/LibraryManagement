using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace LibraryManagement.Application.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandHandler
    : IRequestHandler<CreateAuthorCommand, int>
{
    private readonly IAuthorRepository _authorRepository;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<int> Handle(
        CreateAuthorCommand request,
        CancellationToken cancellationToken)
    {
        var author = request.Adapt<Author>();

        author.CreatedAt = DateTime.UtcNow;
        author.ModifiedAt = DateTime.UtcNow;

        await _authorRepository.AddAsync(author, cancellationToken);

        return author.Id;
    }
}
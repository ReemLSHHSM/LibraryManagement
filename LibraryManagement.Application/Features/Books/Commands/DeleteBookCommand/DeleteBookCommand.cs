using LibraryManagement.Application.Common.Results;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands.DeleteBookCommand;

public class DeleteBookCommand : IRequest<Result>
{
    public int Id { get; set; }
}
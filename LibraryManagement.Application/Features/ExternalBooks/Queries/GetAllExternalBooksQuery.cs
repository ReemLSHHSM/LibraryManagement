using LibraryManagement.Application.Common.Dtos;
using LibraryManagement.Application.Common.Interfaces;
using MediatR;

namespace LibraryManagement.Application.Features.ExternalBooks.Queries
{
  public record GetAllExternalBooksQueryRequest
      : IRequest<List<ExternalBookDto>>;

  public class GetAllExternalBooksQueryHandler
      : IRequestHandler<GetAllExternalBooksQueryRequest, List<ExternalBookDto>>
  {
    private readonly IExternalBookService _externalBookService;

    public GetAllExternalBooksQueryHandler(
        IExternalBookService externalBookService)
    {
      _externalBookService = externalBookService;
    }

    public async Task<List<ExternalBookDto>> Handle(
        GetAllExternalBooksQueryRequest request,
        CancellationToken cancellationToken)
    {
      return await _externalBookService
          .GetBooksAsync(cancellationToken);
    }
  }
}

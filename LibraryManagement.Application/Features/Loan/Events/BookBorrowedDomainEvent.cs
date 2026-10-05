using MediatR;

namespace LibraryManagement.Application.Features.Loans.Events;

public class BookBorrowedDomainEvent : INotification
{
  public int BookId { get; set; }
  public int BorrowerId { get; set; }
}

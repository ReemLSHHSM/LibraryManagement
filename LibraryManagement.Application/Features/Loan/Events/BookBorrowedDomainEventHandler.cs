using MediatR;

namespace LibraryManagement.Application.Features.Loans.Events;

public class BookBorrowedDomainEventHandler
    : INotificationHandler<BookBorrowedDomainEvent>
{
  public Task Handle(
      BookBorrowedDomainEvent notification,
      CancellationToken cancellationToken)
  {
    Console.WriteLine(
        $"Book {notification.BookId} was borrowed by borrower {notification.BorrowerId}");

    return Task.CompletedTask;
  }
}

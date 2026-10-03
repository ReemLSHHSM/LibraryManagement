using LibraryManagement.Application.Common.Results;

namespace LibraryManagement.Application.Features.Books;

public static class BookErrors
{
    public static readonly Error NotFound = new(
        "Book.NotFound",
        ErrorType.NotFound,
        "Book was not found."
    );
}
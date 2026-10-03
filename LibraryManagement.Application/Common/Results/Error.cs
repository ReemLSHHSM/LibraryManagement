namespace LibraryManagement.Application.Common.Results;

public record Error(
    string Code,
    ErrorType Type,
    string Description
);
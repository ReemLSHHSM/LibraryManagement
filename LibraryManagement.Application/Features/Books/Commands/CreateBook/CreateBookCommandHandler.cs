using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Features.Books.Commands.CreateBook
{
  public class CreateBookCommandHandler:IRequestHandler<CreateBookCommand, int>
  {

    private readonly IBookRepository bookRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository)
    {
      this.bookRepository = bookRepository;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
      var book = request.Adapt<Book>();
      await bookRepository.CreateBookAsync(book, cancellationToken);
      return book.Id;
    }
  }
}

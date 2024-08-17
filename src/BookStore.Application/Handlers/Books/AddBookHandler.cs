using BookStore.Application.Commands.Books;
using BookStore.Domain.Book;
using MediatR;

namespace BookStore.Application.Handlers.Books;

public class AddBookHandler : IRequestHandler<AddBookCommand, Book>
{
    private readonly IBookService _bookService;

    public AddBookHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        FreeBook freeBook = new(request.Title, request.Author, request.Pages);
        await _bookService.AddBookAsync(freeBook, request.StoreId, cancellationToken);

        return freeBook;
    }
}

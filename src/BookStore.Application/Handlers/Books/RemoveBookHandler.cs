using BookStore.Application.Commands.Books;
using BookStore.Domain.Book;
using MediatR;

namespace BookStore.Application.Handlers.Books;

public class RemoveBookHandler : IRequestHandler<RemoveBookCommand>
{
    private readonly IBookService _bookService;

    public RemoveBookHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task Handle(RemoveBookCommand request, CancellationToken cancellationToken)
    {
        await _bookService.RemoveBookAsync(request.Id, cancellationToken);
    }
}

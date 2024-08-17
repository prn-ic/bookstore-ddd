using BookStore.Application.Commands.BookStore;
using BookStore.Domain.Book;
using BookStore.Domain.BookStore;
using MediatR;

namespace BookStore.Application.Handlers.BookStore;

public class ReturnBookHandler : IRequestHandler<ReturnBookCommand, FreeBook>
{
    private readonly IBookStoreService _bookStoreService;

    public ReturnBookHandler(IBookStoreService bookStoreService)
    {
        _bookStoreService = bookStoreService;
    }

    public async Task<FreeBook> Handle(
        ReturnBookCommand request,
        CancellationToken cancellationToken
    )
    {
        var freeBook = await _bookStoreService.ReturnBookAsync(
            request.ReturnBookRequest.StoreId,
            request.ReturnBookRequest.BookId,
            request.ReturnBookRequest.CustomerId,
            cancellationToken
        );

        return freeBook;
    }
}

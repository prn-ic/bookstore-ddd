using BookStore.Application.Commands.BookStore;
using BookStore.Domain.Book;
using BookStore.Domain.BookStore;
using MediatR;

namespace BookStore.Application.Handlers.BookStore;

public class RentBookHandler : IRequestHandler<RentBookCommand, RentBook>
{
    private readonly IBookStoreService _bookStoreService;

    public RentBookHandler(IBookStoreService bookStoreService)
    {
        _bookStoreService = bookStoreService;
    }

    public async Task<RentBook> Handle(RentBookCommand request, CancellationToken cancellationToken)
    {
        var rentBook = await _bookStoreService.RentBookAsync(
            request.RentBookRequest.StoreId,
            request.RentBookRequest.BookId,
            request.RentBookRequest.CustomerId,
            cancellationToken
        );

        return rentBook;
    }
}

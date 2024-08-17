using BookStore.Domain.Book;
using BookStore.Domain.Exceptions;

namespace BookStore.Domain.BookStore;

public class BookStoreService : IBookStoreService
{
    private readonly IBookStoreRepository _bookStoreRepository;

    public BookStoreService(IBookStoreRepository bookStoreRepository)
    {
        _bookStoreRepository = bookStoreRepository;
    }

    public async Task<RentBook> RentBookAsync(
        int storeId,
        int bookId,
        int customerId,
        CancellationToken cancellationToken = default
    )
    {
        var bookStore =
            await _bookStoreRepository.GetBookStoreByIdAsync(storeId, cancellationToken)
            ?? throw new NotFoundException<RentBook>(bookId);
        var book = bookStore.RentBook(bookId, customerId);
        await _bookStoreRepository.UpdateBookAsync(book, cancellationToken);

        return book;
    }

    public async Task<FreeBook> ReturnBookAsync(
        int storeId,
        int bookId,
        int customerId,
        CancellationToken cancellationToken = default
    )
    {
        var bookStore =
            await _bookStoreRepository.GetBookStoreByIdAsync(storeId, cancellationToken)
            ?? throw new NotFoundException<FreeBook>(bookId);
        var book = bookStore.ReturnTheBook(bookId, customerId);
        await _bookStoreRepository.UpdateBookAsync(book, cancellationToken);

        return book;
    }
}

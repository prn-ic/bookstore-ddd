using BookStore.Domain.Book;

namespace BookStore.Domain.BookStore;

public interface IBookStoreService
{
    public Task<RentBook> RentBookAsync(int storeId, int bookId, int customerId, CancellationToken cancellationToken = default);
    public Task<FreeBook> ReturnBookAsync(int storeId, int bookId, int customerId, CancellationToken cancellationToken = default);
}
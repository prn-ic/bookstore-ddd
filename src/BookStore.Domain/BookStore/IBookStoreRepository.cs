namespace BookStore.Domain.BookStore;

public interface IBookStoreRepository
{
    public Task<BookStore?> GetBookStoreByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    );
    public Task UpdateBookAsync(
        Book.Book book,
        CancellationToken cancellationToken = default
    );
}

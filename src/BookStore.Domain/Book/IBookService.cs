namespace BookStore.Domain.Book;

public interface IBookService
{
    Task AddBookAsync(Book book, int storeId, CancellationToken cancellationToken = default);
    Task RemoveBookAsync(int id, CancellationToken cancellationToken = default);
}
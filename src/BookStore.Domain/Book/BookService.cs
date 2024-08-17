
namespace BookStore.Domain.Book;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task AddBookAsync(Book book, int storeId, CancellationToken cancellationToken = default)
    {
        await _bookRepository.AddAsync(book, storeId, cancellationToken);
    }

    public async Task RemoveBookAsync(int id, CancellationToken cancellationToken = default)
    {
        await _bookRepository.RemoveAsync(id, cancellationToken);
    }
}
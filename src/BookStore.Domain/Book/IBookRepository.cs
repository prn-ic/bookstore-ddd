using System.Linq.Expressions;

namespace BookStore.Domain.Book;

public interface IBookRepository
{
    Task<IEnumerable<Book>> FindAsync(Expression<Func<Book, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddAsync(Book book, int storeId, CancellationToken cancellationToken = default);
    Task RemoveAsync(int id, CancellationToken cancellationToken = default);
}
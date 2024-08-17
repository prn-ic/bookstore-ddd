using System.Linq.Expressions;
using BookStore.Domain.Book;
using BookStore.Domain.Exceptions;
using BookStore.Persistense.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistense.EntityFramework.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookstoreDbContext _bookstoreDbContext;

    public BookRepository(BookstoreDbContext bookstoreDbContext)
    {
        _bookstoreDbContext = bookstoreDbContext;
    }

    public async Task AddAsync(
        Book book,
        int storeId,
        CancellationToken cancellationToken = default
    )
    {
        var databaseBook = book.Accept(new BookToDatabaseBookMapper());
        databaseBook.BookStoreId = storeId;
        await _bookstoreDbContext.AddAsync(databaseBook, cancellationToken);
        await _bookstoreDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Book>> FindAsync(
        Expression<Func<Book, bool>> predicate,
        CancellationToken cancellationToken = default
    )
    {
        var books = await _bookstoreDbContext
            .Set<Entities.Book>()
            .Select(book => book.ToDomain())
            .Where(predicate)
            .ToListAsync();

        return books;
    }

    public async Task RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        Entities.Book book =
            await _bookstoreDbContext.Books.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new NotFoundException<Book>(id);

        _bookstoreDbContext.Books.Remove(book);
        await _bookstoreDbContext.SaveChangesAsync(cancellationToken);
    }
}

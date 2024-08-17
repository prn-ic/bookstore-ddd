using BookStore.Domain.BookStore;
using BookStore.Persistense.Entities;
using BookStore.Persistense.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistense.EntityFramework.Repositories;

public class BookStoreRepository : IBookStoreRepository
{
    private readonly BookstoreDbContext _bookstoreDbContext;

    public BookStoreRepository(BookstoreDbContext bookstoreDbContext)
    {
        _bookstoreDbContext = bookstoreDbContext;
    }

    public async Task<Domain.BookStore.BookStore?> GetBookStoreByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        var bookStore = await _bookstoreDbContext
            .BookStores.Include(x => x.Books)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return new Domain.BookStore.BookStore(
            bookStore!.Id,
            bookStore!.Books!.Select(book => book.ToDomain())
        );
    }

    public async Task UpdateBookAsync(
        Domain.Book.Book book,
        CancellationToken cancellationToken = default
    )
    {
        var bookFromDatabase = book.Accept(new BookToDatabaseBookMapper());
        await _bookstoreDbContext
            .Books.Where(s => s.Id == bookFromDatabase.Id)
            .ExecuteUpdateAsync(
                calls =>
                    calls
                        .SetProperty(b => b.CustomerId, bookFromDatabase.CustomerId)
                        .SetProperty(b => b.BusyType, bookFromDatabase.BusyType),
                cancellationToken
            );
    }
}

using BookStore.Domain.Book;

namespace BookStore.Persistense.EntityFramework.Data;

public class BookToDatabaseBookMapper : IBookVisitor<Entities.Book>
{
    public Entities.Book Visit(FreeBook freeBook)
    {
        return new()
        {
            Id = freeBook.Id,
            Title = freeBook.Title,
            Author = freeBook.Author,
            Pages = freeBook.Pages,
            CustomerId = null,
            BusyType = Entities.BookBusyType.Free
        };
    }

    public Entities.Book Visit(RentBook rentBook)
    {
        return new()
        {
            Id = rentBook.Id,
            Title = rentBook.Title,
            Author = rentBook.Author,
            Pages = rentBook.Pages,
            CustomerId = rentBook.CustomerId,
            BusyType = Entities.BookBusyType.Busy
        };
    }
}
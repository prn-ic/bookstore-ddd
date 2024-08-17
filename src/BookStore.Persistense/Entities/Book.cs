using BookStore.Domain.Book;
using BookStore.Domain.Exceptions;

namespace BookStore.Persistense.Entities;

public class Book : BaseEntity<int>
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int Pages { get; set; }
    public int? CustomerId { get; set; }
    public int BookStoreId { get; set; }
    public BookBusyType BusyType { get; set; }

    public Domain.Book.Book ToDomain()
    {
        switch (BusyType)
        {
            case BookBusyType.Busy:
                return new RentBook(Title!, Author!, Pages, (int)CustomerId!) { Id = Id };
            case BookBusyType.Free:
                return new FreeBook(Title!, Author!, Pages) { Id = Id };
            default:
                throw new InvalidDataException();
        }
    }
}

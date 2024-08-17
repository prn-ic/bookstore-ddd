using BookStore.Domain.Book;
using BookStore.Domain.Exceptions;

namespace BookStore.Domain.BookStore;

public class BookStore
{
    private readonly Book.Book[] _books;
    public IReadOnlyCollection<Book.Book> Books => _books;
    public int Id { get; set; }

    public BookStore(int id, IEnumerable<Book.Book> books)
    {
        Id = id;
        _books = books.ToArray();
    }

    public FreeBook ReturnTheBook(int bookId, int customerId)
    {
        var book = FindBookById(bookId);
        var returnedBook = book.ReturnTheBook(customerId);

        if (returnedBook == book)
            throw new BookAlreadyTakenException(customerId);

        _books[FindBookIndexById(bookId)] = returnedBook;    
        return returnedBook;
    }

    public RentBook RentBook(int bookId, int customerId)
    {
        var book = FindBookById(bookId);
        var rentedBook = book.Rent(customerId);

        if (rentedBook.CustomerId != customerId)
            throw new BookAlreadyTakenException(customerId);

        _books[FindBookIndexById(bookId)] = rentedBook;
        return rentedBook;
    }

    public Book.Book FindBookById(int id)
    {
        foreach (var book in _books)
        {
            if (book.Id == id)
                return book;
        }

        throw new NotFoundException<Book.Book>(id);
    }

    public int FindBookIndexById(int id)
    {
        for (int i = 0; i < _books.Length; i++)
        {
            if (_books[i].Id == id)
                return i;
        }

        throw new NotFoundException<Book.Book>(id);
    }
}

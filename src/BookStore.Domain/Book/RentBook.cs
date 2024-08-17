using BookStore.Domain.Exceptions;

namespace BookStore.Domain.Book;

public class RentBook : Book
{
    public int? CustomerId { get; set; }

    public RentBook(string title, string author, int pages, int customerId)
        : base(title, author, pages)
    {
        ArgumentNullException.ThrowIfNull(customerId);
        CustomerId = customerId;
    }

    public RentBook(int id, string title, string author, int pages, int customerId)
        : base(title, author, pages)
    {
        Id = id;
        CustomerId = customerId;
    }

    public override T Accept<T>(IBookVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }

    public override bool Equals(Book? other)
    {
        if (other == null)
            return false;

        return other is RentBook rentBook
            && CustomerId == rentBook.CustomerId
            && Title == rentBook.Title
            && Author == rentBook.Author
            && Pages == rentBook.Pages;
    }

    public override bool Equals(object? obj)
    {
        return obj is RentBook book && Equals(book);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Title, Author, Pages, CustomerId);
    }

    public override RentBook Rent(int customerId)
    {
        return CustomerId == customerId || CustomerId is null ? this : throw new BookAlreadyTakenException(customerId);
    }

    public override FreeBook ReturnTheBook(int returneeId)
    {
        return returneeId == CustomerId
            ? new FreeBook(Id, Title, Author, Pages)
            : throw new InvalidBookOwnerException(returneeId, Id);
    }
}

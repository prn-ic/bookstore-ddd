namespace BookStore.Domain.Book;

public class FreeBook : Book
{
    public FreeBook(string title, string author, int pages)
        : base(title, author, pages) { }

    public FreeBook(int id, string title, string author, int pages)
        : base(title, author, pages)
    {
        Id = id;
    }

    public override bool Equals(Book? other)
    {
        if (other == null)
            return false;
        return other is FreeBook book
            && book.Title == book.Title
            && book.Author == book.Author
            && book.Pages == book.Pages;
    }

    public override bool Equals(object? obj)
    {
        return obj is FreeBook book && Equals(book);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Title, Author, Pages);
    }

    public override T Accept<T>(IBookVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }

    public override RentBook Rent(int customerId)
    {
        return new RentBook(Id, Title, Author, Pages, customerId);
    }

    public override FreeBook ReturnTheBook(int returneeId)
    {
        return this;
    }
}

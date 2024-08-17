namespace BookStore.Domain.Book;

public abstract class Book : IEquatable<Book>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }

    public Book(string title, string author, int pages)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentException.ThrowIfNullOrEmpty(author);

        if (pages < 0)
        {
            throw new InvalidDataException("Страниц в книге точно не может быть меньше нуля!!");
        }

        Title = title;
        Author = author;
        Pages = pages;
    }
    public abstract RentBook Rent(int customerId);
    public abstract FreeBook ReturnTheBook(int returneeId);
    public abstract T Accept<T>(IBookVisitor<T> visitor);
    public abstract bool Equals(Book? other);

    public static bool operator ==(Book? left, Book? right)
    {
        return left is null ? right is null : left.Equals(right);
    }

    public static bool operator !=(Book? left, Book? right)
    {
        return !(left == right);
    }

    public abstract override bool Equals(object? obj);

    public abstract override int GetHashCode();
}

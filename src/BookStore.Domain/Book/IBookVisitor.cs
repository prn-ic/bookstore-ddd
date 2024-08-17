namespace BookStore.Domain.Book;

public interface IBookVisitor<out T>
{
    T Visit(FreeBook freeBook);
    T Visit(RentBook rentBook);
}
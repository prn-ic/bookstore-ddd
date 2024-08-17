namespace BookStore.Domain.Exceptions;

public class InvalidBookOwnerException : Exception
{
    public int CustomerId { get; }
    public int BookId { get; }
    public override string Message =>
        string.Format(
            "Customer with id: {0} wasn't owner the book with id: {1}",
            CustomerId,
            BookId
        );

    public InvalidBookOwnerException(int customerId, int bookId)
    {
        CustomerId = customerId;
        BookId = bookId;
    }
}

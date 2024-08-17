namespace BookStore.Domain.Exceptions;

public class BookAlreadyTakenException : DomainException
{
    public int CustomerId { get; }
    public override string Message => $"{CustomerId} was already taken";
    public BookAlreadyTakenException(int customerId)
    {
        CustomerId = customerId;
    }
}
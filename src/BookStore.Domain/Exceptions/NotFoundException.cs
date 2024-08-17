namespace BookStore.Domain.Exceptions;

public class NotFoundException<T> : DomainException
{
    public int Id { get; set; }
    public override string Message => string.Format("{0} wasn't found by id: {1}", typeof(T).Name, Id);

    public NotFoundException(int id)
    {
        Id = id;
    }
}
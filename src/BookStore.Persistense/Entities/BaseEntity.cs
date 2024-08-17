namespace BookStore.Persistense.Entities;

public class BaseEntity<T> where T : struct
{
    public T Id { get; set; }
}
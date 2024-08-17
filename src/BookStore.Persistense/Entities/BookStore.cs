namespace BookStore.Persistense.Entities;

public class BookStore : BaseEntity<int>
{
    public string? Name { get; set; }
    public ICollection<Book>? Books { get; set; }
}

namespace BookStore.Application.Requests;

public class ReturnBookRequest
{
    public int StoreId { get; set; }
    public int BookId { get; set; }
    public int CustomerId { get; set; }
}

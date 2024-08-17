namespace BookStore.Application.Requests;

public class RentBookRequest
{
    public int StoreId { get; set; }
    public int BookId { get; set; }
    public int CustomerId { get; set; }
}

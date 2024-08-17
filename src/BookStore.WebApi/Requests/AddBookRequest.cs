namespace BookStore.WebApi.Requests;

public class AddBookRequest
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public int Pages { get; set; }
    public int StoreId { get; set; }
}

using BookStore.Domain.Book;
using MediatR;

namespace BookStore.Application.Commands.Books;

public class AddBookCommand : IRequest<Book>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public int StoreId { get; set; }

    public AddBookCommand(string title, string author, int pages, int storeId)
    {
        ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
        ArgumentException.ThrowIfNullOrEmpty(author, nameof(author));

        Title = title;
        Author = author;
        Pages = pages;
        StoreId = storeId;
    }
}

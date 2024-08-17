using MediatR;

namespace BookStore.Application.Commands.Books;

public class RemoveBookCommand : IRequest
{
    public int Id { get; set; }

    public RemoveBookCommand(int id)
    {
        Id = id;
    }
}

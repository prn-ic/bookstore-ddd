using BookStore.Application.Requests;
using BookStore.Domain.Book;
using MediatR;

namespace BookStore.Application.Commands.BookStore;

public class RentBookCommand : IRequest<RentBook>
{
    public RentBookRequest RentBookRequest { get; set; }

    public RentBookCommand(RentBookRequest request)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));
        RentBookRequest = request;
    }
}

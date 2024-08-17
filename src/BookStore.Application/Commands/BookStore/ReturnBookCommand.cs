using BookStore.Application.Requests;
using BookStore.Domain.Book;
using MediatR;

namespace BookStore.Application.Commands.BookStore;

public class ReturnBookCommand : IRequest<FreeBook>
{
    public ReturnBookRequest ReturnBookRequest { get; set; }

    public ReturnBookCommand(ReturnBookRequest request)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));
        ReturnBookRequest = request;
    }
}

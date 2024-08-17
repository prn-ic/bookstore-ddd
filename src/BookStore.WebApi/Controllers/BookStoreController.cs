using BookStore.Application.Commands.BookStore;
using BookStore.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookStoreController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookStoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("rent")]
    public async Task<IActionResult> RentBook(
        RentBookRequest request,
        CancellationToken cancellationToken
    )
    {
        var rentBook = await _mediator.Send(new RentBookCommand(request), cancellationToken);
        return Ok(rentBook);
    }

    [HttpPost("free")]
    public async Task<IActionResult> ReturnBook(
        ReturnBookRequest request,
        CancellationToken cancellationToken
    )
    {
        var freeBook = await _mediator.Send(new ReturnBookCommand(request), cancellationToken);
        return Ok(freeBook);
    }
}

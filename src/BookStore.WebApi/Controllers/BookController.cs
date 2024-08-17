using BookStore.Application.Commands.Books;
using BookStore.Domain.Book;
using BookStore.WebApi.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddBook(
        AddBookRequest request,
        CancellationToken cancellationToken
    )
    {
        await _mediator.Send(
            new AddBookCommand(request.Title, request.Author, request.Pages, request.StoreId),
            cancellationToken
        );
        return Accepted();
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveBook(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new RemoveBookCommand(id), cancellationToken);
        return Accepted();
    }
}

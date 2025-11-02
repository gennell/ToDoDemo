using ToDoList.Application.Features.ToDoItems.Commands.Create;
using ToDoList.Application.Features.ToDoItems.Commands.Update;
using ToDoList.Application.Features.ToDoItems.Dtos;
using ToDoList.Application.Features.ToDoItems.Queries.Get;
using ToDoList.Application.Features.ToDoItems.Queries.List;
using ToDoList.Application.Pagination;

namespace ToDoList.API.Controllers;

public class ToDoItemsController(ISender _mediator) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<ToDoItemDto>>> GetToDoItems([FromQuery] PaginationRequest pagination, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ListToDoQuery(pagination), cancellationToken);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItemDto>> GetToDoItemById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new OneToDoItemQuery(id), cancellationToken);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateToDoItem([FromBody] CreateToDoItemDto createToDoItemDto, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateToDoItemCommand(createToDoItemDto), cancellationToken);
        return CreatedAtAction(nameof(GetToDoItemById), new { id = result.Id }, result);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<ToDoItemDto>> UpdateToDoItem(string id, [FromBody] ToDoItemDto updateToDoItemDto, CancellationToken cancellationToken)
    {
        if (id != updateToDoItemDto.Id.ToString())
        {
            return BadRequest();
        }
        var result = await _mediator.Send(new UpdateToDoCommand(updateToDoItemDto), cancellationToken);
        return Ok(result);
    }
}

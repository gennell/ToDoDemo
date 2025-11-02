namespace ToDoList.Application.Features.ToDoItems.Commands.Create;

public class CreateToDoItemCommandHandler(IAppDbContext _context) : IRequestHandler<CreateToDoItemCommand, ToDoItemDto>
{
    public async Task<ToDoItemDto> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var toDoItem = ToDoItem.Create(
            title: request.ToDoItem.Title,
            description: request.ToDoItem.Description,
            toDoDate: request.ToDoItem.ToDoDate,
            status: (ToDoStatus)request.ToDoItem.Status,
            assignedEmail: request.ToDoItem.AssignedEmail);
        await _context.ToDoItems.AddAsync(toDoItem, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return toDoItem.ToDto();
    }
}

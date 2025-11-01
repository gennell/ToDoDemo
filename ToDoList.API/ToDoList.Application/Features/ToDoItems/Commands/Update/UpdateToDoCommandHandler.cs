namespace ToDoList.Application.Features.ToDoItems.Commands.Update;

public class UpdateToDoCommandHandler(IAppDbContext _context) : IRequestHandler<UpdateToDoCommand, ToDoItemDto>
{
    public async Task<ToDoItemDto> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
    {
        var toDoItem = await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (toDoItem is null)
        {
            throw new Exception($"Nie znaleziono zadania o id {request.Id}");
        }
        toDoItem.Update(
            title: request.ToDoItem.Title,
            description: request.ToDoItem.Description,
            toDoDate: request.ToDoItem.ToDoDate,
            status: request.ToDoItem.Status,
            assignedEmail: request.ToDoItem.AssignedEmail);
        await _context.SaveChangesAsync(cancellationToken);
        return toDoItem.ToDto();
    }
}

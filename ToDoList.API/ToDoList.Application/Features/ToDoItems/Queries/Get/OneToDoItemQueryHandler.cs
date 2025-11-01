namespace ToDoList.Application.Features.ToDoItems.Queries.Get;

public class OneToDoItemQueryHandler(IAppDbContext _context) : IRequestHandler<OneToDoItemQuery, ToDoItemDto?>
{
    public async Task<ToDoItemDto?> Handle(OneToDoItemQuery request, CancellationToken cancellationToken)
    {
        var toDoItem = await _context.ToDoItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return toDoItem?.ToDto();
    }
}

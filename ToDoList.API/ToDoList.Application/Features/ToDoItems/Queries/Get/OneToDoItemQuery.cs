namespace ToDoList.Application.Features.ToDoItems.Queries.Get;

public record OneToDoItemQuery(Guid Id) : IRequest<ToDoItemDto?>;
namespace ToDoList.Application.Features.ToDoItems.Dtos;

public record ToDoItemDto(Guid Id, string Title, string Description, DateTime ToDoDate, ToDoStatus Status, string AssignedEmail);

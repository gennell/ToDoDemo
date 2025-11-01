namespace ToDoList.Application.Features.ToDoItems.Dtos;

public record CreateToDoItemDto(string Title, string Description, DateTime ToDoDate, ToDoStatus Status, string AssignedEmail);

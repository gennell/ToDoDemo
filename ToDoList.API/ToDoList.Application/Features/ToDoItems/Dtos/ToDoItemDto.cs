namespace ToDoList.Application.Features.ToDoItems.Dtos;

public class ToDoItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime ToDoDate { get; set; }
    public int Status { get; set; }
    public string AssignedEmail { get; set; } = string.Empty;
}

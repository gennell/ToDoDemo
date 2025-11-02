namespace ToDoList.Domain.Events;

public record ToDoItemUpdateEvent(ToDoItem ToDoItem) : IDomainEvent
{
    
}

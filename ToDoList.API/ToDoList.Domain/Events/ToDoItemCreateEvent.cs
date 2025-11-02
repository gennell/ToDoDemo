namespace ToDoList.Domain.Events;

public record ToDoItemCreateEvent(ToDoItem ToDoItem) : IDomainEvent
{
    
}

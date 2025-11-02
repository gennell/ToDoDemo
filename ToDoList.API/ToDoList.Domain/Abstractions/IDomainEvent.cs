using MediatR;

namespace ToDoList.Domain.Abstractions;

public interface IDomainEvent : INotification
{
    Guid EventId => Guid.NewGuid();
    DateTime OccurredAt => DateTime.UtcNow;
    string EventType => GetType().AssemblyQualifiedName!;
}

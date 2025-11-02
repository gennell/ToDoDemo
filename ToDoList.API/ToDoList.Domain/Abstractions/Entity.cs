namespace ToDoList.Domain.Abstractions
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
        public void SetCreatedAt()
        {
            CreatedAt = DateTime.UtcNow;
        }
        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }
        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public IDomainEvent[] ClearDomainEvents()
        {
            var events = _domainEvents.ToArray();
            _domainEvents.Clear();
            return events;
        }
    }

    public interface IEntity
    {
        Guid Id { get; }
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
        void SetCreatedAt();
        void SetUpdatedAt();
    }
}
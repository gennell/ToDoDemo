using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Entities
{
    public class ToDoItem : Entity
    {
        public string Title { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public DateTime ToDoDate { get; private set; }
        public ToDoStatus Status { get; private set; } = ToDoStatus.NotStarted;
        public string AssignedEmail { get; private set; } = string.Empty;

        public static ToDoItem Create(string title, string? description, DateTime toDoDate, ToDoStatus status, string assignedEmail)
        {
            return new ToDoItem
            {
                Title = title,
                Description = description,
                ToDoDate = toDoDate,
                Status = status,
                AssignedEmail = assignedEmail,
            };
        }

        public void Update(string title, string? description, DateTime toDoDate, ToDoStatus status, string assignedEmail)
        {
            Title = title;
            Description = description;
            ToDoDate = toDoDate;
            Status = status;
            AssignedEmail = assignedEmail;
        }
    }
}
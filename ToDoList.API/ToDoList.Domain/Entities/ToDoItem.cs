using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Entities
{
    public class ToDoItem : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ToDoDate { get; set; }
        public ToDoStatus Status { get; set; } = ToDoStatus.NotStarted;
        public string AssignedEmail { get; set; } = string.Empty;
    }
}
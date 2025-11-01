using ToDoList.Domain.Enums;

namespace ToDoList.Infrastructure.Data.Extensions;

public static class InitializeData
{
    public static List<ToDoItem> ToDoItems = new List<ToDoItem>
    {
        ToDoItem.Create(
            title: "Przykładowy tytuł 1",
            description: "Przykładowy opis 1",
            toDoDate: DateTime.Now.AddDays(1),
            status: ToDoStatus.NotStarted,
            assignedEmail: "john.doe@example.com"),
        ToDoItem.Create(
            title: "Przykładowy tytuł 2",
            description: "Przykładowy opis 2",
            toDoDate: DateTime.Now.AddDays(2),
            status: ToDoStatus.InProgress,
            assignedEmail: "jane.doe@example.com"),
        ToDoItem.Create(
            title: "Przykładowy tytuł 3",
            description: "Przykładowy opis 3",
            toDoDate: DateTime.Now.AddDays(3),
            status: ToDoStatus.Completed,
            assignedEmail: "john.doe@example.com"),
    };
}
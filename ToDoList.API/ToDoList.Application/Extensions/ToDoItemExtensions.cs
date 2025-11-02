using ToDoList.Application.Pagination;

namespace ToDoList.Application.Extensions;

public static class ToDoItemExtensions
{
    public static ToDoItemDto ToDto(this ToDoItem toDoItem)
    {
        return new ToDoItemDto {
            Id = toDoItem.Id, 
            Title = toDoItem.Title, 
            Description = toDoItem.Description, 
            ToDoDate = toDoItem.ToDoDate, 
            Status = (int)toDoItem.Status, 
            AssignedEmail = toDoItem.AssignedEmail };
    }
    public static List<ToDoItemDto> ToDtos(this List<ToDoItem> toDoItems)
    {
        return toDoItems.Select(x => x.ToDto()).ToList();
    }
    // public static PaginatedResult<ToDoItemDto> ToDtos(this PaginatedResult<ToDoItem> paginatedResult)
    // {
    //     return new PaginatedResult<ToDoItemDto>(paginatedResult.Items.ToDtos(), paginatedResult.TotalItems, paginatedResult.PageNumber, paginatedResult.PageSize);
    // }
    public static IQueryable<ToDoItemDto> ToDtos(this IQueryable<ToDoItem> toDoItems)
    {
        return toDoItems.Select(x => x.ToDto());
    }
}

namespace ToDoList.Application.Pagination;

public record PaginationRequest(int PageNumber = 0, int PageSize = 10, DateTime? ToDoDate = null);

using ToDoList.Application.Pagination;

namespace ToDoList.Application.Features.ToDoItems.Queries.List;

public record ListToDoQuery(PaginationRequest Pagination) : IRequest<PaginatedResult<ToDoItemDto>>;
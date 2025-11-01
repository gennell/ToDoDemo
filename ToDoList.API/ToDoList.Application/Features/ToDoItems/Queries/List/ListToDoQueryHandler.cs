using ToDoList.Application.Pagination;

namespace ToDoList.Application.Features.ToDoItems.Queries.List;

public class ListToDoQueryHandler(IAppDbContext _context) : IRequestHandler<ListToDoQuery, PaginatedResult<ToDoItemDto>>
{
    public async Task<PaginatedResult<ToDoItemDto>> Handle(ListToDoQuery request, CancellationToken cancellationToken)
    {
        var query = _context.ToDoItems.AsNoTracking();
        if (request.Pagination.ToDoDate is not null)
        {
            query = query.Where(x => x.ToDoDate.Date == request.Pagination.ToDoDate.Value.Date);
        }
        query = query.OrderByDescending(x => x.ToDoDate);
        return await PaginatedResult<ToDoItemDto>.Create(query.ToDtos(), request.Pagination.PageNumber, request.Pagination.PageSize, cancellationToken);
    }
}

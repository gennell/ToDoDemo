namespace ToDoList.Application.Pagination;

public class PaginatedResult<T>
{
    public List<T> Items { get; }
    public long TotalItems { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

    private PaginatedResult(List<T> items, long totalItems, int pageNumber, int pageSize)
    {
        Items = items;
        TotalItems = totalItems;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    public static async Task<PaginatedResult<T>> Create(IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var totalItems = await query.CountAsync(cancellationToken);
        var items = await query
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        return new PaginatedResult<T>(items, totalItems, pageNumber, pageSize);
    }
}

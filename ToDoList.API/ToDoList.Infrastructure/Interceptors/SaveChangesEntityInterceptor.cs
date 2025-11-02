using Microsoft.EntityFrameworkCore.Diagnostics;
using ToDoList.Domain.Abstractions;

namespace ToDoList.Infrastructure.Interceptors;

public class SaveChangesEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;
        UpdateEntities(context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        UpdateEntities(context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateEntities(DbContext? context)
    {
        if (context is not null)
        {
            foreach (var entry in context.ChangeTracker.Entries<IEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.SetCreatedAt();
                }
                if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                {
                    entry.Entity.SetUpdatedAt();
                }
            }
        }
    }
}

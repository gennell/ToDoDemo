using ToDoList.Infrastructure.Data.Configurations;

namespace ToDoList.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
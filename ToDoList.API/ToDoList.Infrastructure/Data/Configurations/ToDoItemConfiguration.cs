using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoList.Infrastructure.Data.Configurations
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.ToTable("ToDoItems");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(3000);
            builder.Property(x => x.ToDoDate).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.AssignedEmail).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
        }
    }
}
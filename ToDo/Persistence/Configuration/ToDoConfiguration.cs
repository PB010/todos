using System.Data.Entity.ModelConfiguration;
using ToDo.Core.Models;

namespace ToDo.Persistence.Configuration
{
    public class ToDoConfiguration : EntityTypeConfiguration<ToDoList>
    {
        public ToDoConfiguration()
        {
            Property(t => t.CreatedAt)
                .IsRequired();
            
            Property(t => t.Description)
                .IsRequired();
            
            Property(t => t.Id)
                .IsRequired();
            
            HasRequired(t => t.ToDoPriorities);
            
            Property(t => t.Name)
                .HasMaxLength(100);
        }
    }
}
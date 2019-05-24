using System.Data.Entity.ModelConfiguration;
using ToDo.Core.Models;

namespace ToDo.Persistence.Configuration
{
    public class EmailHourCheckConfiguration : EntityTypeConfiguration<EmailHourCheck>
    {
        public EmailHourCheckConfiguration()
        {
            //HasKey(e => new {e.ApplicationUserId, e.ToDoList});
            //
            //Property(e => e.ApplicationUserId)
            //    .HasColumnOrder(1);
            //
            //Property(e => e.ToDoListId)
            //    .HasColumnOrder(2);

        }
    }
}
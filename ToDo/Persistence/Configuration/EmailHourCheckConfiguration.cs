using System.Data.Entity.ModelConfiguration;
using ToDo.Core.Models;

namespace ToDo.Persistence.Configuration
{
    public class EmailHourCheckConfiguration : EntityTypeConfiguration<EmailHourCheck>
    {
        public EmailHourCheckConfiguration()
        {
        }
    }
}
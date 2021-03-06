﻿using System.Data.Entity.ModelConfiguration;
using ToDo.Core.Models;

namespace ToDo.Persistence.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfiguration()
        {
            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
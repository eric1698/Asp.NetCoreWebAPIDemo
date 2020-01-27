using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity.Configuration
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.Property(m => m.Message)
                .HasMaxLength(1024);

            builder.Property(m => m.Name)
                .HasMaxLength(128);
        }
    }
}

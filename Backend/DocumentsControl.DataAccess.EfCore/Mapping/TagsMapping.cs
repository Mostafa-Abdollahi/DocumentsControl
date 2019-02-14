using System;
using System.Collections.Generic;
using System.Text;
using DocumentsControl.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentsControl.DataAccess.EFCore.Mapping
{
    public class TagsMapping : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.Property(x => x.Title).IsRequired();
        }
    }
}

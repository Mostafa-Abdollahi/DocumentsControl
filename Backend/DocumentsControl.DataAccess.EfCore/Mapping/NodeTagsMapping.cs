using System;
using System.Collections.Generic;
using System.Text;
using DocumentsControl.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentsControl.DataAccess.EFCore.Mapping
{
    public class NodeTagsMapping : IEntityTypeConfiguration<NodeTag>
    {
        public void Configure(EntityTypeBuilder<NodeTag> builder)
        {
            builder.ToTable("NodeTags");
            builder.Property(a => a.NodeId).IsRequired();
            builder.Property(a => a.TagId).IsRequired();
            builder.Property(a => a.Value).IsRequired();

        }
    }
}

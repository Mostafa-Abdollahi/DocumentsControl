using System;
using System.Collections.Generic;
using System.Text;
using DocumentsControl.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentsControl.DataAccess.EFCore.Mapping
{
    public class NodesMapping : IEntityTypeConfiguration<Node>
    {
        public void Configure(EntityTypeBuilder<Node> builder)
        {
            builder.ToTable("Nodes");
            builder.Property(a => a.Title).HasMaxLength(250).IsRequired();
            builder.HasOne(a => a.ParentNode)
                .WithMany(a => a.Children)
                .HasForeignKey(a => a.ParentNodeId);
        }
    }
}

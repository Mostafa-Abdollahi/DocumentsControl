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
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.DateCreated).IsRequired(false);
            builder.Property(a => a.DateModified).IsRequired(false);
            builder.Property(a => a.IsFile).HasDefaultValue(false);

            builder.HasOne(a => a.ParentNode)
                .WithMany(a => a.Children)
                .HasForeignKey(a => a.ParentNodeId);
        }
    }
}

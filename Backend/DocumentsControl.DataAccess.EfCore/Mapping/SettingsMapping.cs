using System;
using System.Collections.Generic;
using System.Text;
using DocumentsControl.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentsControl.DataAccess.EFCore.Mapping

{
    public class SettingsMapping : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Settings");
            builder.Property(x => x.RootPath).IsRequired();
        }
    }
}

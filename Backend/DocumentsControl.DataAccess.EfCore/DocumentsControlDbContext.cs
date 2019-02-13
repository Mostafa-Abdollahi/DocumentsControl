using System;
using System.Collections.Generic;
using System.Text;
using DocumentsControl.DataAccess.EFCore.Mapping;
using DocumentsControl.Domain;
using Microsoft.EntityFrameworkCore;

namespace DocumentsControl.DataAccess.EFCore
{
    public class DocumentsControlDbContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: remove this hard-coded connection string
            optionsBuilder.UseSqlServer(@"data source=.;initial catalog=DocumentsControl;integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NodesMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}

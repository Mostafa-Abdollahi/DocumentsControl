﻿using System;
using System.Collections.Generic;
using System.Text;
using Academy.DataAccess.EFCore.Mapping;
using DocumentsControl.Domain;
using Microsoft.EntityFrameworkCore;

namespace Academy.DataAccess.EFCore
{
    public class AcademyDbContext : DbContext
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
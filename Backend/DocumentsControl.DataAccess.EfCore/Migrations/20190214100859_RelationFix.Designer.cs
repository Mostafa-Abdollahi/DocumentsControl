﻿// <auto-generated />
using System;
using DocumentsControl.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DocumentsControl.DataAccess.EfCore.Migrations
{
    [DbContext(typeof(DocumentsControlDbContext))]
    [Migration("20190214100859_RelationFix")]
    partial class RelationFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DocumentsControl.Domain.Node", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsFile")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<long?>("ParentNodeId");

                    b.Property<string>("Path");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("ParentNodeId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("DocumentsControl.Domain.NodeTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("NodeId");

                    b.Property<long>("TagId");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("TagId");

                    b.ToTable("NodeTags");
                });

            modelBuilder.Entity("DocumentsControl.Domain.Setting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RootPath")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("DocumentsControl.Domain.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DocumentsControl.Domain.Node", b =>
                {
                    b.HasOne("DocumentsControl.Domain.Node", "ParentNode")
                        .WithMany("Children")
                        .HasForeignKey("ParentNodeId");
                });

            modelBuilder.Entity("DocumentsControl.Domain.NodeTag", b =>
                {
                    b.HasOne("DocumentsControl.Domain.Node", "node")
                        .WithMany()
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DocumentsControl.Domain.Tag", "tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

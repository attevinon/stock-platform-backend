﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stock.Persistence;

#nullable disable

namespace Stock.UI.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    partial class RepositoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Stock.Domain.Entities.Author", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Username");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Stock.Domain.Entities.ConcreteProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorUsername")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductAuthorUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("Sales")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorUsername");

                    b.HasIndex("ProductAuthorUsername");

                    b.ToTable("ConcreteProduct");
                });

            modelBuilder.Entity("Stock.Domain.Entities.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductAuthorUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("Sales")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProductAuthorUsername");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Stock.Domain.Entities.Text", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductAuthorUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("Sales")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProductAuthorUsername");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("Stock.Domain.Entities.ConcreteProduct", b =>
                {
                    b.HasOne("Stock.Domain.Entities.Author", null)
                        .WithMany("OwnedProducts")
                        .HasForeignKey("AuthorUsername");

                    b.HasOne("Stock.Domain.Entities.Author", "ProductAuthor")
                        .WithMany()
                        .HasForeignKey("ProductAuthorUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductAuthor");
                });

            modelBuilder.Entity("Stock.Domain.Entities.Photo", b =>
                {
                    b.HasOne("Stock.Domain.Entities.Author", "ProductAuthor")
                        .WithMany()
                        .HasForeignKey("ProductAuthorUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductAuthor");
                });

            modelBuilder.Entity("Stock.Domain.Entities.Text", b =>
                {
                    b.HasOne("Stock.Domain.Entities.Author", "ProductAuthor")
                        .WithMany()
                        .HasForeignKey("ProductAuthorUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductAuthor");
                });

            modelBuilder.Entity("Stock.Domain.Entities.Author", b =>
                {
                    b.Navigation("OwnedProducts");
                });
#pragma warning restore 612, 618
        }
    }
}

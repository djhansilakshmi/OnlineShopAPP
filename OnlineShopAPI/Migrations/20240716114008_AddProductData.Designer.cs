﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShopAPI.Data;

#nullable disable

namespace OnlineShopAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240716114008_AddProductData")]
    partial class AddProductData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineShopAPI.Models.Attributes", b =>
                {
                    b.Property<int>("AttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttributeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttributeId");

                    b.HasIndex("ProductID");

                    b.ToTable("attributes");
                });

            modelBuilder.Entity("OnlineShopAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7663),
                            Name = "Electronics",
                            UpdatedDate = new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7679)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7681),
                            Name = "MensShirts",
                            UpdatedDate = new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7683)
                        });
                });

            modelBuilder.Entity("OnlineShopAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InventoryAvailable")
                        .HasColumnType("int");

                    b.Property<int>("InventoryReserved")
                        .HasColumnType("int");

                    b.Property<int>("InventoryTotal")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryID");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Amount = 1299.99,
                            Brand = "Brand Name",
                            CategoryID = 1,
                            CreatedDate = new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7889),
                            Currency = "USD",
                            Description = "Powerful and lightweight laptop for work and entertainment.",
                            InventoryAvailable = 20,
                            InventoryReserved = 5,
                            InventoryTotal = 25,
                            Name = "Laptop",
                            UpdatedDate = new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7890)
                        });
                });

            modelBuilder.Entity("OnlineShopAPI.Models.Attributes", b =>
                {
                    b.HasOne("OnlineShopAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShopAPI.Models.Product", b =>
                {
                    b.HasOne("OnlineShopAPI.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });
#pragma warning restore 612, 618
        }
    }
}

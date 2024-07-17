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
    [Migration("20240716114211_AddAttributeData")]
    partial class AddAttributeData
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

                    b.HasData(
                        new
                        {
                            AttributeId = 1,
                            Name = "Color",
                            ProductID = 1,
                            Value = "Silver"
                        },
                        new
                        {
                            AttributeId = 2,
                            Name = "Processor",
                            ProductID = 1,
                            Value = "Intel Core i7"
                        },
                        new
                        {
                            AttributeId = 3,
                            Name = "Memory",
                            ProductID = 1,
                            Value = "16GB"
                        },
                        new
                        {
                            AttributeId = 4,
                            Name = "Storage",
                            ProductID = 1,
                            Value = "512GB SSD"
                        });
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
                            CreatedDate = new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(6990),
                            Name = "Electronics",
                            UpdatedDate = new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(7014)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(7022),
                            Name = "MensShirts",
                            UpdatedDate = new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(7024)
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
                            CreatedDate = new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(7685),
                            Currency = "USD",
                            Description = "Powerful and lightweight laptop for work and entertainment.",
                            InventoryAvailable = 20,
                            InventoryReserved = 5,
                            InventoryTotal = 25,
                            Name = "Laptop",
                            UpdatedDate = new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(7687)
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

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 16, 12, 56, 37, 473, DateTimeKind.Local).AddTicks(2999), "Electronics", new DateTime(2024, 7, 16, 12, 56, 37, 473, DateTimeKind.Local).AddTicks(3013) },
                    { 2, new DateTime(2024, 7, 16, 12, 56, 37, 473, DateTimeKind.Local).AddTicks(3017), "MensShirts", new DateTime(2024, 7, 16, 12, 56, 37, 473, DateTimeKind.Local).AddTicks(3018) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}

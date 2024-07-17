using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAttributeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "attributes",
                columns: new[] { "AttributeId", "Name", "ProductID", "Value" },
                values: new object[,]
                {
                    { 1, "Color", 1, "Silver" },
                    { 2, "Processor", 1, "Intel Core i7" },
                    { 3, "Memory", 1, "16GB" },
                    { 4, "Storage", 1, "512GB SSD" }
                });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(6990), new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(7014) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(7022), new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(7024) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(7685), new DateTime(2024, 7, 16, 17, 12, 11, 61, DateTimeKind.Local).AddTicks(7687) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "attributes",
                keyColumn: "AttributeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "attributes",
                keyColumn: "AttributeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "attributes",
                keyColumn: "AttributeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "attributes",
                keyColumn: "AttributeId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7663), new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7679) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7681), new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7683) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7889), new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7890) });
        }
    }
}

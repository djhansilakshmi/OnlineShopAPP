using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "Amount", "Brand", "CategoryID", "CreatedDate", "Currency", "Description", "InventoryAvailable", "InventoryReserved", "InventoryTotal", "Name", "UpdatedDate" },
                values: new object[] { 1, 1299.99, "Brand Name", 1, new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7889), "USD", "Powerful and lightweight laptop for work and entertainment.", 20, 5, 25, "Laptop", new DateTime(2024, 7, 16, 17, 10, 7, 541, DateTimeKind.Local).AddTicks(7890) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 16, 16, 59, 53, 129, DateTimeKind.Local).AddTicks(7819), new DateTime(2024, 7, 16, 16, 59, 53, 129, DateTimeKind.Local).AddTicks(7833) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 16, 16, 59, 53, 129, DateTimeKind.Local).AddTicks(7837), new DateTime(2024, 7, 16, 16, 59, 53, 129, DateTimeKind.Local).AddTicks(7838) });
        }
    }
}

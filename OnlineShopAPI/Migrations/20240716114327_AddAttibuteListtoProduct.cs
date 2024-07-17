using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAttibuteListtoProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 16, 17, 13, 26, 492, DateTimeKind.Local).AddTicks(2270), new DateTime(2024, 7, 16, 17, 13, 26, 492, DateTimeKind.Local).AddTicks(2285) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 16, 17, 13, 26, 492, DateTimeKind.Local).AddTicks(2288), new DateTime(2024, 7, 16, 17, 13, 26, 492, DateTimeKind.Local).AddTicks(2289) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 16, 17, 13, 26, 492, DateTimeKind.Local).AddTicks(2502), new DateTime(2024, 7, 16, 17, 13, 26, 492, DateTimeKind.Local).AddTicks(2504) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

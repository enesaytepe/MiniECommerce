using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init_mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDateTime", "Name", "ParentCategoryId", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 2, 3, 14, 5, 52, 305, DateTimeKind.Utc).AddTicks(8426), "Category 1", null, null },
                    { 6L, new DateTime(2025, 2, 3, 14, 5, 52, 305, DateTimeKind.Utc).AddTicks(8437), "Category 2", null, null },
                    { 7L, new DateTime(2025, 2, 3, 14, 5, 52, 305, DateTimeKind.Utc).AddTicks(8438), "Category 3", null, null },
                    { 2L, new DateTime(2025, 2, 3, 14, 5, 52, 305, DateTimeKind.Utc).AddTicks(8431), "Category 1-1", 1L, null },
                    { 5L, new DateTime(2025, 2, 3, 14, 5, 52, 305, DateTimeKind.Utc).AddTicks(8434), "Category 1-2", 1L, null },
                    { 8L, new DateTime(2025, 2, 3, 14, 5, 52, 305, DateTimeKind.Utc).AddTicks(8439), "Category 3-1", 7L, null },
                    { 3L, new DateTime(2025, 2, 3, 14, 5, 52, 305, DateTimeKind.Utc).AddTicks(8432), "Category 1-1-1", 2L, null },
                    { 4L, new DateTime(2025, 2, 3, 14, 5, 52, 305, DateTimeKind.Utc).AddTicks(8433), "Category 1-1-2", 2L, null },
                    { 9L, new DateTime(2025, 2, 3, 14, 5, 52, 305, DateTimeKind.Utc).AddTicks(8440), "Category 3-1-1", 8L, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Author1" });

            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedDate", "Title" },
                values: new object[] { 1, 1, "Blog1 Content", new DateTime(2024, 10, 17, 4, 48, 28, 543, DateTimeKind.Utc).AddTicks(6064), "Blog1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blog",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

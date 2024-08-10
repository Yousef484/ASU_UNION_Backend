using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_UNION.Migrations
{
    /// <inheritdoc />
    public partial class newcolumnaddedtopoststablenotifiedcolumntocheckthereispostsshouldbesenttousersemails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5c9ee9-e88e-4300-b52d-22733499bed1");

            migrationBuilder.AddColumn<bool>(
                name: "notified",
                table: "Postss",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef9a2bd5-aa0a-4319-805a-18c402bdf456", null, "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef9a2bd5-aa0a-4319-805a-18c402bdf456");

            migrationBuilder.DropColumn(
                name: "notified",
                table: "Postss");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b5c9ee9-e88e-4300-b52d-22733499bed1", null, "Admin", "ADMIN" });
        }
    }
}

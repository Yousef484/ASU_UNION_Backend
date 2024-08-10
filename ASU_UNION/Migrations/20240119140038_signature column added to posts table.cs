using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_UNION.Migrations
{
    /// <inheritdoc />
    public partial class signaturecolumnaddedtopoststable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410906b2-3211-41cf-afa8-255c76edbf33");

            migrationBuilder.AlterColumn<int>(
                name: "numberOfLikes",
                table: "Postss",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "signature",
                table: "Postss",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6185a2d-6e9c-48bf-830b-51729a6cdd78", null, "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6185a2d-6e9c-48bf-830b-51729a6cdd78");

            migrationBuilder.DropColumn(
                name: "signature",
                table: "Postss");

            migrationBuilder.AlterColumn<int>(
                name: "numberOfLikes",
                table: "Postss",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "410906b2-3211-41cf-afa8-255c76edbf33", null, "Admin", "ADMIN" });
        }
    }
}

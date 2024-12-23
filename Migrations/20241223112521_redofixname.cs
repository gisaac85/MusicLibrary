using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicLibrary.Migrations
{
    /// <inheritdoc />
    public partial class redofixname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Artists",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Queen");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Led Zeppelin");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Eagles");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "John Lennon");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Nirvana");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Metallica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Artists",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Queen", "" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Led", "Zeppelin" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Eagles", "" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "John", "Lennon" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Nirvana", "" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Metallica", "" });
        }
    }
}

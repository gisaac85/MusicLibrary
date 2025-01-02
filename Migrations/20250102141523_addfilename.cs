using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicLibrary.Migrations
{
    /// <inheritdoc />
    public partial class addfilename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "FileName",
                value: "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Queen-BohemianRhapsody.mp3");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2,
                column: "FileName",
                value: "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Led-Zeppelin-Stairway-To-Heaven.mp3");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3,
                column: "FileName",
                value: "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Eagles-Hotel-California.mp3");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4,
                column: "FileName",
                value: "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\John-Lennon-Imagine.mp3");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 5,
                column: "FileName",
                value: "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Metallica-Smells-Like-Teen-Spiri.mp3");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 6,
                column: "FileName",
                value: "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Metallica-One.mp3");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 7,
                column: "FileName",
                value: "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Backstreet Boys - Everybody.mp3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Songs");
        }
    }
}

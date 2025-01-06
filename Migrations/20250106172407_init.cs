using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicLibrary.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Queen" },
                    { 2, "Led Zeppelin" },
                    { 3, "Eagles" },
                    { 4, "John Lennon" },
                    { 5, "Nirvana" },
                    { 6, "Metallica" },
                    { 7, "BSB" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Grunge" },
                    { 3, "Metal" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "ArtistId", "File", "FileName", "GenreId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, "C:\\Users\\HP\\source\\repos\\MusicLibrary\\wwwroot\\Uploads\\Queen-BohemianRhapsody.mp3", 1, new DateOnly(1975, 10, 31), "Bohemian Rhapsody" },
                    { 2, 2, null, "C:\\Users\\HP\\source\\repos\\MusicLibrary\\wwwroot\\Uploads\\Led-Zeppelin-Stairway-To-Heaven.mp3", 1, new DateOnly(1971, 11, 8), "Stairway to Heaven" },
                    { 3, 1, null, "C:\\Users\\HP\\source\\repos\\MusicLibrary\\wwwroot\\Uploads\\Eagles-Hotel-California.mp3", 1, new DateOnly(1977, 12, 8), "Hotel California" },
                    { 4, 4, null, "C:\\Users\\HP\\source\\repos\\MusicLibrary\\wwwroot\\Uploads\\John-Lennon-Imagine.mp3", 1, new DateOnly(1971, 10, 11), "Imagine" },
                    { 5, 6, null, "C:\\Users\\HP\\source\\repos\\MusicLibrary\\wwwroot\\Uploads\\Metallica-Smells-Like-Teen-Spiri.mp3", 2, new DateOnly(1991, 9, 10), "Smells Like Teen Spirit" },
                    { 6, 3, null, "C:\\Users\\HP\\source\\repos\\MusicLibrary\\wwwroot\\Uploads\\Metallica-One.mp3", 3, new DateOnly(1989, 8, 25), "One" },
                    { 7, 7, null, "C:\\Users\\HP\\source\\repos\\MusicLibrary\\wwwroot\\Uploads\\Backstreet Boys - Everybody.mp3", 2, new DateOnly(1999, 1, 10), "Everybody" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}

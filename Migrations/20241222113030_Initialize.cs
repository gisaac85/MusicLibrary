using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "ArtistName", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Queen", "Rock", new DateTime(1975, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bohemian Rhapsody" },
                    { 2, "Led Zeppelin", "Rock", new DateTime(1971, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stairway to Heaven" },
                    { 3, "Eagles", "Rock", new DateTime(1977, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hotel California" },
                    { 4, "John Lennon", "Rock", new DateTime(1971, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Imagine" },
                    { 5, "Nirvana", "Grunge", new DateTime(1991, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smells Like Teen Spirit" },
                    { 6, "Metallica", "Metal", new DateTime(1989, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "One" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}

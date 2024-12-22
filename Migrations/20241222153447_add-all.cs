using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicLibrary.Migrations
{
    /// <inheritdoc />
    public partial class addall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "ArtistName", "GenreId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Queen", 1, new DateTime(1975, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bohemian Rhapsody" },
                    { 2, "Led Zeppelin", 1, new DateTime(1971, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stairway to Heaven" },
                    { 3, "Eagles", 1, new DateTime(1977, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hotel California" },
                    { 4, "John Lennon", 1, new DateTime(1971, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Imagine" },
                    { 5, "Nirvana", 2, new DateTime(1991, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smells Like Teen Spirit" },
                    { 6, "Metallica", 3, new DateTime(1989, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "One" }
                });

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
                name: "Genres");
        }
    }
}

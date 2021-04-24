using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smoos.Data.Migrations
{
    public partial class AddMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<string>(type: "varchar(20)", nullable: false),
                    Summary = table.Column<string>(type: "varchar(max)", nullable: false),
                    Country = table.Column<string>(type: "varchar(20)", nullable: false),
                    MovieGenres = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    ReleaseYear = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistMovie",
                columns: table => new
                {
                    ActorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistMovie", x => new { x.ActorsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_ArtistMovie_Artists_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistMovie_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMovie_MoviesId",
                table: "ArtistMovie",
                column: "MoviesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistMovie");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}

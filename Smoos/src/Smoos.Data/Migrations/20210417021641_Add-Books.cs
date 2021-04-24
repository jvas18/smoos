using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smoos.Data.Migrations
{
    public partial class AddBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMovie_Movie_MoviesId",
                table: "ArtistMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pages = table.Column<string>(type: "varchar(10)", nullable: false),
                    Summary = table.Column<string>(type: "varchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "varchar(20)", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    ReleaseYear = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ArtistId",
                table: "Books",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMovie_Movies_MoviesId",
                table: "ArtistMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMovie_Movies_MoviesId",
                table: "ArtistMovie");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMovie_Movie_MoviesId",
                table: "ArtistMovie",
                column: "MoviesId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

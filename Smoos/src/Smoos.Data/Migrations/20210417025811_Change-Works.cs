using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smoos.Data.Migrations
{
    public partial class ChangeWorks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AlbumId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SongId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AlbumId",
                table: "Ratings",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BookId",
                table: "Ratings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SongId",
                table: "Ratings",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Albums_AlbumId",
                table: "Ratings",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Books_BookId",
                table: "Ratings",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Songs_SongId",
                table: "Ratings",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Albums_AlbumId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Books_BookId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Songs_SongId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_AlbumId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_BookId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_SongId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Ratings");
        }
    }
}

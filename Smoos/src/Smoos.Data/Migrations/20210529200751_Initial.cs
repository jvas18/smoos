using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smoos.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "varchar(max)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccuredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<string>(type: "varchar(20)", nullable: false),
                    Summary = table.Column<string>(type: "varchar(max)", nullable: false),
                    Country = table.Column<string>(type: "varchar(20)", nullable: false),
                    MovieGenres = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    ReleaseYear = table.Column<string>(type: "varchar(4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(5)", nullable: false),
                    Poster = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityKeys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Parameters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Algorithm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(90)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profile = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<string>(type: "varchar(50)", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    ReleaseYear = table.Column<string>(type: "varchar(4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(5)", nullable: false),
                    Poster = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    ReleaseYear = table.Column<string>(type: "varchar(4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(5)", nullable: false),
                    Poster = table.Column<string>(type: "varchar(max)", nullable: false)
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
                        name: "FK_ArtistMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "suggestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_suggestions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<string>(type: "varchar(30)", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    ReleaseYear = table.Column<string>(type: "varchar(4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(5)", nullable: false),
                    Poster = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "varchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(200)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AlbumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AlbumId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BookId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MovieId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SongId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Albums_AlbumId1",
                        column: x => x.AlbumId1,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Books_BookId1",
                        column: x => x.BookId1,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieId1",
                        column: x => x.MovieId1,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Songs_SongId1",
                        column: x => x.SongId1,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMovie_MoviesId",
                table: "ArtistMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ArtistId",
                table: "Books",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AlbumId",
                table: "Ratings",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AlbumId1",
                table: "Ratings",
                column: "AlbumId1");


            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BookId1",
                table: "Ratings",
                column: "BookId1");


            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId1",
                table: "Ratings",
                column: "MovieId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SongId1",
                table: "Ratings",
                column: "SongId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_suggestions_UserId",
                table: "suggestions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistMovie");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "SecurityKeys");

            migrationBuilder.DropTable(
                name: "suggestions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}

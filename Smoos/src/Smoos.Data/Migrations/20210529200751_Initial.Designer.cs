// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smoos.Data;

namespace Smoos.Data.Migrations
{
    [DbContext(typeof(SmoosContext))]
    [Migration("20210529200751_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArtistMovie", b =>
                {
                    b.Property<Guid>("ActorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ActorsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("ArtistMovie");
                });

            modelBuilder.Entity("Jwks.Manager.SecurityKeyWithPrivate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Algorithm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("KeyId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SecurityKeys");
                });

            modelBuilder.Entity("Smoos.Domain.Albums.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(5)");

                    b.Property<string>("ReleaseYear")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Smoos.Domain.Artists.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("Age");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Smoos.Domain.Books.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Pages")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(5)");

                    b.Property<string>("ReleaseYear")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Smoos.Domain.Logs.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Exception");

                    b.Property<string>("Level")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Level");

                    b.Property<string>("Logger")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Logger");

                    b.Property<string>("Message")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Level");

                    b.Property<DateTime?>("OccurredAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("OccuredAt");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Smoos.Domain.Movies.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("MovieGenres")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(5)");

                    b.Property<string>("ReleaseYear")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Smoos.Domain.Ratings.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MovieId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SongId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SongId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("AlbumId1");

                    b.HasIndex("BookId");

                    b.HasIndex("BookId1");

                    b.HasIndex("MovieId");

                    b.HasIndex("MovieId1");

                    b.HasIndex("SongId");

                    b.HasIndex("SongId1");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Smoos.Domain.Songs.Song", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(5)");

                    b.Property<string>("ReleaseYear")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("Smoos.Domain.Suggestions.Suggestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("suggestions");
                });

            modelBuilder.Entity("Smoos.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(90)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Password");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Picture");

                    b.Property<string>("UserProfile")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasColumnName("Profile");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ArtistMovie", b =>
                {
                    b.HasOne("Smoos.Domain.Artists.Artist", null)
                        .WithMany()
                        .HasForeignKey("ActorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smoos.Domain.Movies.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Smoos.Domain.Albums.Album", b =>
                {
                    b.HasOne("Smoos.Domain.Artists.Artist", "Singer")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Singer");
                });

            modelBuilder.Entity("Smoos.Domain.Books.Book", b =>
                {
                    b.HasOne("Smoos.Domain.Artists.Artist", "Author")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Smoos.Domain.Ratings.Rating", b =>
                {
                    b.HasOne("Smoos.Domain.Albums.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId");

                    b.HasOne("Smoos.Domain.Albums.Album", null)
                        .WithMany("Ratings")
                        .HasForeignKey("AlbumId1");

                    b.HasOne("Smoos.Domain.Books.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Smoos.Domain.Books.Book", null)
                        .WithMany("Ratings")
                        .HasForeignKey("BookId1");

                    b.HasOne("Smoos.Domain.Movies.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("Smoos.Domain.Movies.Movie", null)
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId1");

                    b.HasOne("Smoos.Domain.Songs.Song", "Song")
                        .WithMany()
                        .HasForeignKey("SongId");

                    b.HasOne("Smoos.Domain.Songs.Song", null)
                        .WithMany("Ratings")
                        .HasForeignKey("SongId1");

                    b.HasOne("Smoos.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Book");

                    b.Navigation("Movie");

                    b.Navigation("Song");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Smoos.Domain.Songs.Song", b =>
                {
                    b.HasOne("Smoos.Domain.Albums.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Smoos.Domain.Artists.Artist", "Author")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.Navigation("Album");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Smoos.Domain.Suggestions.Suggestion", b =>
                {
                    b.HasOne("Smoos.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Smoos.Domain.Albums.Album", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Smoos.Domain.Books.Book", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Smoos.Domain.Movies.Movie", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Smoos.Domain.Songs.Song", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}

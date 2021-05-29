using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smoos.Domain.Ratings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Mapping
{
    public class RatingMap : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Comment)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(x => x.Stars)
                 .IsRequired()
                 .HasColumnType("int");

            builder.Property(x => x.CreatedAt)
                 .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Movie)
              .WithMany()
              .HasForeignKey(x => x.MovieId)
              .IsRequired(false);

            builder.HasOne(x => x.Book)
             .WithMany()
             .HasForeignKey(x => x.BookId)
             .IsRequired(false);

            builder.HasOne(x => x.Song)
             .WithMany()
             .HasForeignKey(x => x.SongId)
             .IsRequired(false);
            builder.HasOne(x => x.Album)
            .WithMany()
            .HasForeignKey(x => x.AlbumId)
            .IsRequired(false);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smoos.Domain.Albums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Mapping
{
    public class AlbumMap : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {

            builder.ToTable("Albums");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(x => x.ReleaseYear)
                .IsRequired()
                .HasColumnType("varchar(4)");

            builder.Property(x => x.Duration)
            .IsRequired()
            .HasColumnType("varchar(50)");


            builder.HasOne(x => x.Singer)
                .WithMany()
                .HasForeignKey(x => x.ArtistId);

            builder.Property(x => x.Poster)
           .IsRequired()
           .HasColumnType("varchar(max)");

            builder.Property(x => x.Rate)
            .IsRequired()
            .HasColumnType("decimal(5)");

        }
    }
}

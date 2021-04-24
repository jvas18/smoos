using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smoos.Domain.Songs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Mapping
{
    public class SongMap : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Songs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(x => x.ReleaseYear)
                .IsRequired()
                .HasColumnType("varchar(4)");

            builder.Property(x => x.Duration)
               .IsRequired()
               .HasColumnType("varchar(30)");

            builder.HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.ArtistId);

            builder.HasMany(x => x.Ratings)
                    .WithOne();
        }
    }
}

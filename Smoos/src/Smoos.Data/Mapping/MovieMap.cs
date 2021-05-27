using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smoos.Domain.Movies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Mapping
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(x => x.ReleaseYear)
                .IsRequired()
                .HasColumnType("varchar(4)");

            builder.Property(x => x.Summary)
               .IsRequired()
               .HasColumnType("varchar(max)");

            builder.Property(x => x.Duration)
            .IsRequired()
            .HasColumnType("varchar(20)");

            builder.Property(x => x.Country)
                 .IsRequired()
                 .HasColumnType("varchar(20)");
            builder.Property(x => x.Rate)
            .IsRequired()
            .HasColumnType("decimal(5)");

            builder.Property(x => x.MovieGenres)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasMany(x => x.Actors)
                .WithMany(x => x.Movies);

            builder.HasMany(x => x.Ratings)
            .WithOne();


        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smoos.Domain.Books;
using System;
using System.Collections.Generic;
using System.Text;
namespace Smoos.Data.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

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

            builder.Property(x => x.Pages)
            .IsRequired()
            .HasColumnType("varchar(10)");

            builder.Property(x => x.Poster)
           .IsRequired()
           .HasColumnType("varchar(max)");

            builder.Property(x => x.Publisher)
                 .IsRequired()
                 .HasColumnType("varchar(20)");
            builder.Property(x => x.Rate)
            .IsRequired()
            .HasColumnType("decimal(5)");

            builder.HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.ArtistId);
        }
    }
}

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

            builder.Property(x => x.Stars)
                 .IsRequired()
                 .HasColumnType("int");

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}

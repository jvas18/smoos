using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smoos.Domain.Artists;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Mapping
{
    public class ArtistMap : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Name");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasColumnName("Description");

            builder.Property(x => x.Age)
               .IsRequired()
               .HasColumnName("Age");

            builder.ToTable("Artists");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smoos.Domain.Suggestions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Mapping
{
    public class SuggestionsMap : IEntityTypeConfiguration<Suggestion>
    {
        public void Configure(EntityTypeBuilder<Suggestion> builder)
        {
            builder.ToTable("suggestions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                  .IsRequired()
                  .HasColumnType("varchar(max)");

            builder.Property(x => x.Category)
                 .IsRequired()
                 .HasColumnType("varchar(50)");

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

        }
    }
}

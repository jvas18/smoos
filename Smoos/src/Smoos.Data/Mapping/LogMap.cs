using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smoos.Domain.Logs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Mapping
{
    internal class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Exception)
                .HasColumnName("Exception")
                .IsRequired(false);

            builder.Property(x => x.Level)
                .HasColumnName("Level")
                .IsRequired(false);

            builder.Property(x => x.Logger)
            .HasColumnName("Logger")
            .IsRequired(false);

            builder.Property(x => x.OccurredAt)
            .HasColumnName("OccuredAt")
            .IsRequired(false);

            builder.Property(x => x.Message)
            .HasColumnName("Level")
            .IsRequired(false);

            builder.ToTable("Log");
        }
    }
}

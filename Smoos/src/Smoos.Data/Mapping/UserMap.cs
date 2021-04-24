using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smoos.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(90)");

            builder.Property(x=>x.Password)
                 .IsRequired()
                   .HasColumnName("Password")
                 .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(x => x.Picture)
                  .HasColumnName("Picture")
                .IsRequired(false);

            builder.Property(x => x.UserProfile)
                .IsRequired()
                .HasColumnType("varchar(60)")
                 .HasColumnName("Profile");

            builder.ToTable("Users");
        }
    }
}

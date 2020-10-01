using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.FirstName).IsRequired().IsUnicode(true).HasMaxLength(255);
            builder.Property(x => x.LastName).IsRequired().IsUnicode(true).HasMaxLength(255);
            builder.Property(x => x.Dob).IsRequired();
        }
    }
}

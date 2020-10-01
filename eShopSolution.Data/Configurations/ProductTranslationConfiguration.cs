using eShopSolution.Data.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("ProductTranslations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().IsUnicode(true).HasMaxLength(50);
            builder.Property(x => x.SeoDescription).IsUnicode(true).HasMaxLength(50);
            builder.Property(x => x.SeoTile).IsUnicode(true).HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().IsUnicode(true).HasMaxLength(255);
            builder.Property(x => x.Details).IsRequired().IsUnicode(true).HasMaxLength(255);

        }
    }
}

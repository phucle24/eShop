using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eShopSolution.Data.Enitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCaregory>
    {
        public void Configure(EntityTypeBuilder<ProductInCaregory> builder)
        {
            builder.HasKey(t => new {t.CategoryId, t.ProductId });
            builder.ToTable("ProductInCategories");
            builder.HasOne(t => t.Product).WithMany(pr => pr.ProductInCaregories)
                .HasForeignKey(pr => pr.ProductId);
            builder.HasOne(t => t.Category).WithMany(pc => pc.ProductInCaregories)
               .HasForeignKey(c => c.CategoryId);
        }
    }
}

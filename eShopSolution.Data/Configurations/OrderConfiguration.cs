using Microsoft.EntityFrameworkCore;
using eShopSolution.Data.Enitities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(o => o.ShipEmail).IsUnicode(false).HasMaxLength(50);
        }
    }
}

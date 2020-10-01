using eShopSolution.Data.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OderDetails");
            builder.HasKey(x => new { x.OrderId, x.ProductId });
            builder.HasOne(o => o.Order)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(o => o.OrderId);
            builder.HasOne(o => o.Product).WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductId);
        }
    }
}

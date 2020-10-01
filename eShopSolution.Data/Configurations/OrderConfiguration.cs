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
            builder.Property(o => o.OrderDate).HasDefaultValue(DateTime.Now);
            builder.Property(o => o.ShipEmail).IsUnicode(false).HasMaxLength(250);
            builder.Property(o => o.ShipAdress).IsRequired().HasMaxLength(250);
            builder.Property(o => o.ShipName).IsRequired().IsUnicode(true).HasMaxLength(250);
            builder.Property(o => o.ShipPhone).IsRequired().HasMaxLength(250);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);

        }
    }
}

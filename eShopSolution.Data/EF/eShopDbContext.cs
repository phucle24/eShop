using eShopSolution.Data.Configuration;
using eShopSolution.Data.Configurations;
using eShopSolution.Data.Enitities;
using eShopSolution.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.EF
{
    public class eShopDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public eShopDbContext( DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure using Fluent API
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(
                x=>new { x.RoleId, x.UserId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            // DataSeeding
            modelBuilder.Sees();
            // base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { set; get; }
        public DbSet<Category> Categories{ set; get; }
        public DbSet<ProductInCaregory> ProductInCaregories{ set; get; }
        public DbSet<ProductTranslation> ProductTranslations{ set; get; }
        public DbSet<CategoryTranslation> CategoryTranslations{ set; get; }
        public DbSet<Contact> Contacts{ set; get; }
        public DbSet<Language> Languages{ set; get; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails{ set; get; }
        public DbSet<Promotion> Promotions{ set; get; }
        public DbSet<Transaction> Transactions{ set; get; }
        public DbSet<Cart> Carts{ set; get; }
        public DbSet<AppConfig> AppConfigs{ set; get; }
        public DbSet<ProductImage> ProductImages{ set; get; }
    }
}

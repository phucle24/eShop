using eShopSolution.Data.Enitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Sees(this ModelBuilder modelBuilder)
        {
            // DataSeeding
            modelBuilder.Entity<AppConfig>().HasData(
                 new AppConfig() { Key = "HomeTitle", Value = "This is Title of eShop" },
                 new AppConfig() { Key = "HomeKeyword", Value = "This is Keyword of eShop" },
                 new AppConfig() { Key = "HomeDesciption", Value = "This is Desciption of eShop" }
            );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false }

                );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Enums.Status.Active,
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Enums.Status.Active,
                });
            modelBuilder.Entity<CategoryTranslation>().HasData(
                        new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo Nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDesciption = "Sản phẩm áo nam", SeoTile = "Áo thời trang nam" },
                        new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "T-shirt", LanguageId = "en-US", SeoAlias = "the-tshirt", SeoDesciption = "Product of men", SeoTile = "Product fashion man" },
                        new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo Nữ", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDesciption = "Sản phẩm áo nữ", SeoTile = "Áo thời trang nữ" },
                        new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women-shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDesciption = "Product of women", SeoTile = "Product fashion women" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 20000,
                    Price = 10000,
                    Stock = 0,
                    ViewCount = 0,
                });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Áo sơ mi Nam",
                     LanguageId = "vi-VN",
                     SeoDescription = "Sản phẩm áo nam",
                     SeoTile = "Áo thời trang nam",
                     Details = "Sản phẩm nam siêu đẹp",
                     Description = "Siêu đẹp"
                 },
                 new ProductTranslation()
                 {
                     Id = 2,
                     ProductId = 1,
                     Name = "T-shirt",
                     LanguageId = "en-US",
                     SeoDescription = "Product of men",
                     SeoTile = "Product fashion man",
                     Details = "Product beautifull for man",
                     Description = "Very beatifull"
                 });
            modelBuilder.Entity<ProductInCaregory>().HasData(
                 new ProductInCaregory() { ProductId =1,CategoryId =1}     
                );
        }
    }
}

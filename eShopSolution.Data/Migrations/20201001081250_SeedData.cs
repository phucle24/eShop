using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTitle", "This is Title of eShop" },
                    { "HomeKeyword", "This is Keyword of eShop" },
                    { "HomeDesciption", "This is Desciption of eShop" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "vi-VN", true, "Tiếng Việt" },
                    { "en-US", false, "English" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreated", "OriginalPrice", "Price" },
                values: new object[] { 1, new DateTime(2020, 10, 1, 15, 12, 48, 881, DateTimeKind.Local).AddTicks(3140), 20000m, 10000m });

            migrationBuilder.InsertData(
                table: "CategotyTranslations",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDesciption", "SeoTile" },
                values: new object[,]
                {
                    { 1, 1, "vi-VN", "Áo Nam", "ao-nam", "Sản phẩm áo nam", "Áo thời trang nam" },
                    { 3, 2, "vi-VN", "Áo Nữ", "ao-nam", "Sản phẩm áo nữ", "Áo thời trang nữ" },
                    { 2, 1, "en-US", "T-shirt", "the-tshirt", "Product of men", "Product fashion man" },
                    { 4, 2, "en-US", "Women-shirt", "women-shirt", "Product of women", "Product fashion women" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductTranslations",
                columns: new[] { "Id", "Description", "Details", "LanguageId", "Name", "ProductId", "SeoDescription", "SeoTile" },
                values: new object[,]
                {
                    { 1, "Siêu đẹp", "Sản phẩm nam siêu đẹp", "vi-VN", "Áo sơ mi Nam", 1, "Sản phẩm áo nam", "Áo thời trang nam" },
                    { 2, "Very beatifull", "Product beautifull for man", "en-US", "T-shirt", 1, "Product of men", "Product fashion man" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDesciption");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyword");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "CategotyTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategotyTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategotyTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategotyTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "en-US");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "vi-VN");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 1, 16, 46, 23, 220, DateTimeKind.Local).AddTicks(9525));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    isDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 2, 10, 14, 41, 510, DateTimeKind.Local).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9f09d620-7951-42e3-b116-740815cee6f8"),
                column: "ConcurrencyStamp",
                value: "d4aaa6d4-043c-4b3b-81bd-1b9e8a73c77b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ac4babcd-36de-4ea0-bbb1-9d5264846f1a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "77e44660-82ee-4b24-ad8c-1c7b2821714f", "AQAAAAEAACcQAAAAEFlpNHYEEwi12uscgNVvJAx34tU8r9fJaveb+bC3eQ1HAn9smF9ixkCKWtGtFsrNQg==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 1, 16, 46, 23, 220, DateTimeKind.Local).AddTicks(9525),
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 1, 16, 46, 23, 238, DateTimeKind.Local).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9f09d620-7951-42e3-b116-740815cee6f8"),
                column: "ConcurrencyStamp",
                value: "a6187515-bf9a-45d6-b1da-7a987f65b0b9");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ac4babcd-36de-4ea0-bbb1-9d5264846f1a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "acdeb631-3720-4ab9-9964-646c030e1c88", "AQAAAAEAACcQAAAAEOdRqivs65PGk+MSpFQQq/CVG9/+lhSOqXVZqU/dURd6ScFlQ+yLAhINu7P5FRwW8w==" });
        }
    }
}

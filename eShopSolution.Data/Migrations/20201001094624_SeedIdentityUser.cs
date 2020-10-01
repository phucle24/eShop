using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 1, 16, 46, 23, 220, DateTimeKind.Local).AddTicks(9525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 1, 16, 26, 9, 567, DateTimeKind.Local).AddTicks(2096));

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9f09d620-7951-42e3-b116-740815cee6f8"), new Guid("ac4babcd-36de-4ea0-bbb1-9d5264846f1a") });

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("9f09d620-7951-42e3-b116-740815cee6f8"), "a6187515-bf9a-45d6-b1da-7a987f65b0b9", "Adminstator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ac4babcd-36de-4ea0-bbb1-9d5264846f1a"), 0, "acdeb631-3720-4ab9-9964-646c030e1c88", new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "phucle@gmail.com", true, "Phuc", "Le", false, null, "phucle@gmail.com", "admin", "AQAAAAEAACcQAAAAEOdRqivs65PGk+MSpFQQq/CVG9/+lhSOqXVZqU/dURd6ScFlQ+yLAhINu7P5FRwW8w==", null, false, "", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9f09d620-7951-42e3-b116-740815cee6f8"), new Guid("ac4babcd-36de-4ea0-bbb1-9d5264846f1a") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9f09d620-7951-42e3-b116-740815cee6f8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ac4babcd-36de-4ea0-bbb1-9d5264846f1a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 1, 16, 26, 9, 567, DateTimeKind.Local).AddTicks(2096),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 1, 16, 46, 23, 220, DateTimeKind.Local).AddTicks(9525));

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
                value: new DateTime(2020, 10, 1, 16, 26, 9, 587, DateTimeKind.Local).AddTicks(7898));
        }
    }
}

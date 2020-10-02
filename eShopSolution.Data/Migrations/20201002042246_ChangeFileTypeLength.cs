using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangeFileTypeLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                value: new DateTime(2020, 10, 2, 11, 22, 44, 595, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9f09d620-7951-42e3-b116-740815cee6f8"),
                column: "ConcurrencyStamp",
                value: "9fd13ea4-e048-4a87-9a2e-ffa91c9328b5");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ac4babcd-36de-4ea0-bbb1-9d5264846f1a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6ddb8e39-7320-427a-a98d-2b659418d5af", "AQAAAAEAACcQAAAAEJm5ljMuxjyUL1fKjZjTbwHG2sJnbPOKBUgiiBODR4EmkOgxvQjIRfoyqXBmXxmzIg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

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
        }
    }
}

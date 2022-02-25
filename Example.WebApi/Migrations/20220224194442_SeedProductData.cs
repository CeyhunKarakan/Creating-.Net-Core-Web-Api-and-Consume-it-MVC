using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Example.WebApi.Migrations
{
    public partial class SeedProductData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImagePath", "Name", "Price", "Stock", "createdDate" },
                values: new object[] { 1, null, "TV", 3000m, 50, new DateTime(2022, 2, 21, 22, 44, 42, 370, DateTimeKind.Local).AddTicks(8008) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImagePath", "Name", "Price", "Stock", "createdDate" },
                values: new object[] { 2, null, "Table", 1750m, 750, new DateTime(2022, 2, 9, 22, 44, 42, 371, DateTimeKind.Local).AddTicks(7821) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImagePath", "Name", "Price", "Stock", "createdDate" },
                values: new object[] { 3, null, "Keyboard", 100m, 125, new DateTime(2022, 2, 23, 22, 44, 42, 371, DateTimeKind.Local).AddTicks(7844) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

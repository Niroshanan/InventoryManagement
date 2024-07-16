using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("17318580-e82f-4496-8340-00b94e4f7a46"), "asd", "Grocery" },
                    { new Guid("58e52409-4f60-4c0d-8b62-205b92131135"), "asd", "Clothing" },
                    { new Guid("be88a383-10f2-4a7b-973a-c62c34c75172"), "asd", "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0a597b86-958a-4998-8bd9-42e8a13c6b08"), new Guid("17318580-e82f-4496-8340-00b94e4f7a46"), "Rice", 10 },
                    { new Guid("15d1c248-a90c-434d-9d72-7d45f2b24c9a"), new Guid("be88a383-10f2-4a7b-973a-c62c34c75172"), "Laptop", 1000 },
                    { new Guid("3fdb768b-980f-4cda-8ffb-6c8f230b52e4"), new Guid("58e52409-4f60-4c0d-8b62-205b92131135"), "T-shirt", 20 },
                    { new Guid("70272fb7-3f1d-4128-833b-ddc9ecc9a4b2"), new Guid("58e52409-4f60-4c0d-8b62-205b92131135"), "Jeans", 50 },
                    { new Guid("d748627d-e99e-4680-b68f-13cc4ad31765"), new Guid("be88a383-10f2-4a7b-973a-c62c34c75172"), "Mobile Phone", 500 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a597b86-958a-4998-8bd9-42e8a13c6b08"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("15d1c248-a90c-434d-9d72-7d45f2b24c9a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3fdb768b-980f-4cda-8ffb-6c8f230b52e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("70272fb7-3f1d-4128-833b-ddc9ecc9a4b2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d748627d-e99e-4680-b68f-13cc4ad31765"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("17318580-e82f-4496-8340-00b94e4f7a46"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("58e52409-4f60-4c0d-8b62-205b92131135"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("be88a383-10f2-4a7b-973a-c62c34c75172"));
        }
    }
}

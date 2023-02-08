using Microsoft.EntityFrameworkCore.Migrations;

namespace Mango.Services.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Praesent scelerisque, magna vehicula sagittis ut non Phasellus commodo cursus pretium.", "https://salimmawlaa.blob.core.windows.net/mango/1.jpg", "Samosa", 15.0 },
                    { 2, "Appetizer", "Praesent scelerisque, mi sed ultriceem, laturpis, facilisis sed ligula ac, maximus malesuada", "https://salimmawlaa.blob.core.windows.net/mango/3.jpg", "Paneer Tikka", 13.99 },
                    { 3, "Dessert", "Praesent scelerisqSed volutpat tellus lorem, lacinia tinciduellus commodo cursus pretium.", "https://salimmawlaa.blob.core.windows.net/mango/4.jpg", "Sweet Pie", 10.99 },
                    { 4, "Entree", "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in loborti", "https://salimmawlaa.blob.core.windows.net/mango/5.jpg", "Pav Bhaji", 15.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");
        }
    }
}

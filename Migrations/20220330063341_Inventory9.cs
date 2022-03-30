using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystem.Migrations
{
    public partial class Inventory9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Product_Access",
                table: "USERS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Products_ID1",
                table: "PRODUCTS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Product_Access",
                table: "USERS",
                column: "Product_Access");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_Products_ID1",
                table: "PRODUCTS",
                column: "Products_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_PRODUCTS_Products_ID1",
                table: "PRODUCTS",
                column: "Products_ID1",
                principalTable: "PRODUCTS",
                principalColumn: "Products_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_PRODUCTS_Product_Access",
                table: "USERS",
                column: "Product_Access",
                principalTable: "PRODUCTS",
                principalColumn: "Products_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_PRODUCTS_Products_ID1",
                table: "PRODUCTS");

            migrationBuilder.DropForeignKey(
                name: "FK_USERS_PRODUCTS_Product_Access",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_USERS_Product_Access",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCTS_Products_ID1",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "Product_Access",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "Products_ID1",
                table: "PRODUCTS");
        }
    }
}

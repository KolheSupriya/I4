using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystem.Migrations
{
    public partial class Inventory13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_PRODUCTS_Products_ID1",
                table: "PRODUCTS");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCTS_Products_ID1",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "Products_ID1",
                table: "PRODUCTS");

            migrationBuilder.AddColumn<int>(
                name: "Products_ID",
                table: "USERS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Products_ID",
                table: "USERS",
                column: "Products_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_PRODUCTS_Products_ID",
                table: "USERS",
                column: "Products_ID",
                principalTable: "PRODUCTS",
                principalColumn: "Products_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USERS_PRODUCTS_Products_ID",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_USERS_Products_ID",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "Products_ID",
                table: "USERS");

            migrationBuilder.AddColumn<int>(
                name: "Products_ID1",
                table: "PRODUCTS",
                type: "int",
                nullable: true);

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
        }
    }
}

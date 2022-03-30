using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystem.Migrations
{
    public partial class Inventory15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

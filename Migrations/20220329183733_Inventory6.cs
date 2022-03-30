using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystem.Migrations
{
    public partial class Inventory6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHIPPING");

            migrationBuilder.DropTable(
                name: "INVOICE_DATA");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "PRODUCT_CATEGORIES");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "PRODUCTS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "PRODUCTS");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "PRODUCT_CATEGORIES",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "INVOICE_DATA",
                columns: table => new
                {
                    Invoice_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Payment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_Price = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Unit_Sold = table.Column<int>(type: "int", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICE_DATA", x => x.Invoice_ID);
                });

            migrationBuilder.CreateTable(
                name: "SHIPPING",
                columns: table => new
                {
                    Shipping_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Invoice_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Shipped_From = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Shipped_To = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Shipping_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sold_Quantity = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Total_Price = table.Column<int>(type: "int", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPPING", x => x.Shipping_ID);
                    table.ForeignKey(
                        name: "FK_SHIPPING_INVOICE_DATA_Invoice_ID",
                        column: x => x.Invoice_ID,
                        principalTable: "INVOICE_DATA",
                        principalColumn: "Invoice_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SHIPPING_PRODUCTS_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "Products_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SHIPPING_Invoice_ID",
                table: "SHIPPING",
                column: "Invoice_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPPING_Product_ID",
                table: "SHIPPING",
                column: "Product_ID");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystem.Migrations
{
    public partial class Inventory1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INVOICE_DATA",
                columns: table => new
                {
                    Invoice_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Unit_Sold = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Total_Price = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Payment_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICE_DATA", x => x.Invoice_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_CATEGORIES",
                columns: table => new
                {
                    Product_Category_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_CATEGORIES", x => x.Product_Category_ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    Products_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Category_ID = table.Column<int>(type: "int", nullable: false),
                    SubProduct_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Current_Storage = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Sold = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Remaining_Quantity = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Unit_Price = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Total_Selling_Amount = table.Column<int>(type: "int", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.Products_ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_PRODUCT_CATEGORIES_Product_Category_ID",
                        column: x => x.Product_Category_ID,
                        principalTable: "PRODUCT_CATEGORIES",
                        principalColumn: "Product_Category_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_ID = table.Column<int>(type: "int", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Zip_Code = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_USERS_ROLES_Role_ID",
                        column: x => x.Role_ID,
                        principalTable: "ROLES",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SHIPPING",
                columns: table => new
                {
                    Shipping_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Invoice_ID = table.Column<int>(type: "int", nullable: false),
                    Customer_ID = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Sold_Quantity = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Shipping_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shipped_From = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Shipped_To = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                name: "IX_PRODUCTS_Product_Category_ID",
                table: "PRODUCTS",
                column: "Product_Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPPING_Invoice_ID",
                table: "SHIPPING",
                column: "Invoice_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPPING_Product_ID",
                table: "SHIPPING",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Role_ID",
                table: "USERS",
                column: "Role_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHIPPING");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "INVOICE_DATA");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "PRODUCT_CATEGORIES");
        }
    }
}

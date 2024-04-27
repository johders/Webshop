using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PE1.Webshop.Web.Migrations
{
    public partial class AddWebOrdersTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    Shipping = table.Column<decimal>(type: "decimal(6,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebOrderCoffee",
                columns: table => new
                {
                    WebOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebOrderCoffee", x => new { x.WebOrderId, x.CoffeeId });
                    table.ForeignKey(
                        name: "FK_WebOrderCoffee_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebOrderCoffee_WebOrders_WebOrderId",
                        column: x => x.WebOrderId,
                        principalTable: "WebOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebOrderCoffee_CoffeeId",
                table: "WebOrderCoffee",
                column: "CoffeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebOrderCoffee");

            migrationBuilder.DropTable(
                name: "WebOrders");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PE1.Webshop.Web.Migrations
{
    public partial class UpdateOrderAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebOrderCoffee_Coffees_CoffeeId",
                table: "WebOrderCoffee");

            migrationBuilder.DropForeignKey(
                name: "FK_WebOrderCoffee_WebOrders_WebOrderId",
                table: "WebOrderCoffee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WebOrderCoffee",
                table: "WebOrderCoffee");

            migrationBuilder.RenameTable(
                name: "WebOrderCoffee",
                newName: "WebOrderCoffeeDetails");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameIndex(
                name: "IX_WebOrderCoffee_CoffeeId",
                table: "WebOrderCoffeeDetails",
                newName: "IX_WebOrderCoffeeDetails_CoffeeId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "WebOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebOrderCoffeeDetails",
                table: "WebOrderCoffeeDetails",
                columns: new[] { "WebOrderId", "CoffeeId" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$uRqx5Ey49itrQgLIXszUrw$QhoDtwO7JLI+e9v/VKSpXza0UwUm4pTI5SOe95d2ZwQ");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$bVKJ+TcUG0GxbIY6OoZSvw$aQEkOyH4dIkqbtZOj9eCJXZxVQ7X+jhm/rTVxp0ekTs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$35YwlKM6bfoW9z2qYu6hEg$ui8MGm78kfQwh93v/99vSzl3bgwsx0wzodh0nZ604GA");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$ZNaCoG9+tCfqHBCOXJvqgA$MV+wAaGMN4ygL/ky5kloskzLc5BVIGDAQ6S4QV0jEZw");

            migrationBuilder.AddForeignKey(
                name: "FK_WebOrderCoffeeDetails_Coffees_CoffeeId",
                table: "WebOrderCoffeeDetails",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WebOrderCoffeeDetails_WebOrders_WebOrderId",
                table: "WebOrderCoffeeDetails",
                column: "WebOrderId",
                principalTable: "WebOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebOrderCoffeeDetails_Coffees_CoffeeId",
                table: "WebOrderCoffeeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_WebOrderCoffeeDetails_WebOrders_WebOrderId",
                table: "WebOrderCoffeeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WebOrderCoffeeDetails",
                table: "WebOrderCoffeeDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "WebOrders");

            migrationBuilder.RenameTable(
                name: "WebOrderCoffeeDetails",
                newName: "WebOrderCoffee");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PassWord");

            migrationBuilder.RenameIndex(
                name: "IX_WebOrderCoffeeDetails_CoffeeId",
                table: "WebOrderCoffee",
                newName: "IX_WebOrderCoffee_CoffeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebOrderCoffee",
                table: "WebOrderCoffee",
                columns: new[] { "WebOrderId", "CoffeeId" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$A8v+NZJPEiuWQw6oB7Iq4A$+t871B4NKi73YhXjS5aJsWcujqEJtwBDRP2wPCXyTYQ");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$culo6EVMVAELofKvYEUlZw$YssFaV3fU7ygGRz8K/P1JpRI5O080lIYBbD5zwgr8x8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$5pomdZljJMFdemVxdv3RXQ$dGBBnYE96KNOQm3ULOZaUuAXPiNwwvmuzoWTFxXUBUE");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$OHqUT5wlQ4VlBBSwJOV23Q$mDeQJyL57eOG/Vm7lMM+1wpl4RPyvjwdU+TaFGQK/iw");

            migrationBuilder.AddForeignKey(
                name: "FK_WebOrderCoffee_Coffees_CoffeeId",
                table: "WebOrderCoffee",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WebOrderCoffee_WebOrders_WebOrderId",
                table: "WebOrderCoffee",
                column: "WebOrderId",
                principalTable: "WebOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

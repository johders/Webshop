using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PE1.Webshop.Web.Migrations
{
    public partial class AddOrderData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$973eI2wyUhVS5a+aNQgwZg$q278YxcKa6ebKTFPKURrVy4bboT0XJLI8xDNYacToCE");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$Dw+cpKIhTsjJeXtdlz3h5g$MyZTBYquk+kGZIeH+fG4k/iIgBjqUCozPy+2sx/VkhU");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$iR3k3Rb15mu4Nzo2XlLKYw$yDM7LNMjQ6CvPjIZggv5HkKK4m8AhKTxIJf95T9BJ5c");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$7UJkqSg77oSuJIlLzgNSug$5PRWZK7Xd8wG1VWaMoLi+YuM9jhZovXIVQbE6RZuQq0");

            migrationBuilder.InsertData(
                table: "WebOrders",
                columns: new[] { "Id", "OrderDate", "Shipping", "Status", "SubTotal", "TotalPrice", "TotalQuantity", "UserId" },
                values: new object[,]
                {
                    { new Guid("1889c918-f35f-4cc3-b2b1-ffd7560eff90"), new DateTime(2024, 5, 3, 17, 39, 1, 80, DateTimeKind.Local).AddTicks(8034), 3.95m, "Unshipped", 58.5m, 62.45m, 3, 3 },
                    { new Guid("6a106996-b534-466b-884c-f26437bf4017"), new DateTime(2024, 5, 3, 17, 7, 1, 80, DateTimeKind.Local).AddTicks(7951), 0m, "Unshipped", 83.5m, 83.5m, 4, 1 },
                    { new Guid("802bdd11-8b5b-440b-b2e2-699a4e6bb978"), new DateTime(2024, 5, 3, 17, 51, 1, 80, DateTimeKind.Local).AddTicks(8038), 6.95m, "Completed", 37.5m, 44.45m, 2, 4 },
                    { new Guid("a1dcfd6a-bda1-419d-a946-a73b046cfc90"), new DateTime(2024, 5, 3, 21, 7, 1, 80, DateTimeKind.Local).AddTicks(8024), 0m, "Completed", 111m, 111m, 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "WebOrderCoffeeDetails",
                columns: new[] { "CoffeeId", "WebOrderId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 4, new Guid("1889c918-f35f-4cc3-b2b1-ffd7560eff90"), 1, 18.5m },
                    { 8, new Guid("1889c918-f35f-4cc3-b2b1-ffd7560eff90"), 1, 19m },
                    { 16, new Guid("1889c918-f35f-4cc3-b2b1-ffd7560eff90"), 1, 21m },
                    { 6, new Guid("6a106996-b534-466b-884c-f26437bf4017"), 2, 20m },
                    { 10, new Guid("6a106996-b534-466b-884c-f26437bf4017"), 1, 25m },
                    { 12, new Guid("6a106996-b534-466b-884c-f26437bf4017"), 1, 18.5m },
                    { 5, new Guid("a1dcfd6a-bda1-419d-a946-a73b046cfc90"), 4, 19m },
                    { 9, new Guid("a1dcfd6a-bda1-419d-a946-a73b046cfc90"), 2, 17.5m },
                    { 11, new Guid("a1dcfd6a-bda1-419d-a946-a73b046cfc90"), 1, 18.5m },
                    { 14, new Guid("a1dcfd6a-bda1-419d-a946-a73b046cfc90"), 1, 19m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WebOrderCoffeeDetails",
                keyColumns: new[] { "CoffeeId", "WebOrderId" },
                keyValues: new object[] { 4, new Guid("1889c918-f35f-4cc3-b2b1-ffd7560eff90") });

            migrationBuilder.DeleteData(
                table: "WebOrderCoffeeDetails",
                keyColumns: new[] { "CoffeeId", "WebOrderId" },
                keyValues: new object[] { 8, new Guid("1889c918-f35f-4cc3-b2b1-ffd7560eff90") });

            migrationBuilder.DeleteData(
                table: "WebOrderCoffeeDetails",
                keyColumns: new[] { "CoffeeId", "WebOrderId" },
                keyValues: new object[] { 16, new Guid("1889c918-f35f-4cc3-b2b1-ffd7560eff90") });

            migrationBuilder.DeleteData(
                table: "WebOrderCoffeeDetails",
                keyColumns: new[] { "CoffeeId", "WebOrderId" },
                keyValues: new object[] { 6, new Guid("6a106996-b534-466b-884c-f26437bf4017") });

            migrationBuilder.DeleteData(
                table: "WebOrderCoffeeDetails",
                keyColumns: new[] { "CoffeeId", "WebOrderId" },
                keyValues: new object[] { 10, new Guid("6a106996-b534-466b-884c-f26437bf4017") });

            migrationBuilder.DeleteData(
                table: "WebOrderCoffeeDetails",
                keyColumns: new[] { "CoffeeId", "WebOrderId" },
                keyValues: new object[] { 12, new Guid("6a106996-b534-466b-884c-f26437bf4017") });

            migrationBuilder.DeleteData(
                table: "WebOrderCoffeeDetails",
                keyColumns: new[] { "CoffeeId", "WebOrderId" },
                keyValues: new object[] { 5, new Guid("a1dcfd6a-bda1-419d-a946-a73b046cfc90") });

            migrationBuilder.DeleteData(
                table: "WebOrderCoffeeDetails",
                keyColumns: new[] { "CoffeeId", "WebOrderId" },
                keyValues: new object[] { 9, new Guid("a1dcfd6a-bda1-419d-a946-a73b046cfc90") });

            migrationBuilder.DeleteData(
                table: "WebOrderCoffeeDetails",
                keyColumns: new[] { "CoffeeId", "WebOrderId" },
                keyValues: new object[] { 11, new Guid("a1dcfd6a-bda1-419d-a946-a73b046cfc90") });

            migrationBuilder.DeleteData(
                table: "WebOrderCoffeeDetails",
                keyColumns: new[] { "CoffeeId", "WebOrderId" },
                keyValues: new object[] { 14, new Guid("a1dcfd6a-bda1-419d-a946-a73b046cfc90") });

            migrationBuilder.DeleteData(
                table: "WebOrders",
                keyColumn: "Id",
                keyValue: new Guid("802bdd11-8b5b-440b-b2e2-699a4e6bb978"));

            migrationBuilder.DeleteData(
                table: "WebOrders",
                keyColumn: "Id",
                keyValue: new Guid("1889c918-f35f-4cc3-b2b1-ffd7560eff90"));

            migrationBuilder.DeleteData(
                table: "WebOrders",
                keyColumn: "Id",
                keyValue: new Guid("6a106996-b534-466b-884c-f26437bf4017"));

            migrationBuilder.DeleteData(
                table: "WebOrders",
                keyColumn: "Id",
                keyValue: new Guid("a1dcfd6a-bda1-419d-a946-a73b046cfc90"));

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
        }
    }
}

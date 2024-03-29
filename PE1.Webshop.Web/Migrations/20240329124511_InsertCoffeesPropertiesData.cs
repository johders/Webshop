using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PE1.Webshop.Web.Migrations
{
    public partial class InsertCoffeesPropertiesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CoffeeProperty",
                columns: new[] { "CoffeesId", "PropertiesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 1 },
                    { 3, 7 },
                    { 3, 8 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 9 },
                    { 5, 1 },
                    { 5, 3 },
                    { 5, 10 },
                    { 6, 11 },
                    { 6, 12 },
                    { 6, 13 },
                    { 7, 1 },
                    { 7, 14 },
                    { 7, 15 },
                    { 8, 1 },
                    { 8, 14 },
                    { 8, 16 },
                    { 9, 16 },
                    { 9, 17 },
                    { 9, 18 },
                    { 10, 13 },
                    { 10, 19 },
                    { 10, 20 },
                    { 11, 1 },
                    { 11, 12 },
                    { 11, 17 },
                    { 12, 21 },
                    { 12, 22 },
                    { 12, 23 },
                    { 13, 1 },
                    { 13, 14 },
                    { 13, 17 },
                    { 14, 2 },
                    { 14, 12 },
                    { 14, 24 }
                });

            migrationBuilder.InsertData(
                table: "CoffeeProperty",
                columns: new[] { "CoffeesId", "PropertiesId" },
                values: new object[,]
                {
                    { 15, 2 },
                    { 15, 11 },
                    { 15, 20 },
                    { 16, 13 },
                    { 16, 19 },
                    { 16, 24 },
                    { 17, 13 },
                    { 17, 19 },
                    { 17, 20 },
                    { 18, 5 },
                    { 18, 9 },
                    { 18, 20 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 7, 14 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 7, 15 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 8, 14 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 8, 16 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 9, 16 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 9, 17 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 9, 18 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 10, 19 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 10, 20 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 11, 12 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 11, 17 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 12, 21 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 12, 22 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 12, 23 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 13, 14 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 13, 17 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 14, 12 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 14, 24 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 15, 11 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 15, 20 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 16, 13 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 16, 19 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 16, 24 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 17, 13 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 17, 19 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 17, 20 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 18, 5 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 18, 9 });

            migrationBuilder.DeleteData(
                table: "CoffeeProperty",
                keyColumns: new[] { "CoffeesId", "PropertiesId" },
                keyValues: new object[] { 18, 20 });
        }
    }
}

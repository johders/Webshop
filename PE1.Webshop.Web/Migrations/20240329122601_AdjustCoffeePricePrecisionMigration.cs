using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PE1.Webshop.Web.Migrations
{
    public partial class AdjustCoffeePricePrecisionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Coffees",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageString", "Name" },
                values: new object[,]
                {
                    { 1, "~/images/roast-1.jpg", "Light Roast" },
                    { 2, "~/images/roast-2.jpg", "Medium Roast" },
                    { 3, "~/images/roast-3.jpg", "Dark Roast" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chocolate" },
                    { 2, "Citrus" },
                    { 3, "Almond" },
                    { 4, "Vanilla" },
                    { 5, "Lemon" },
                    { 6, "Bright" },
                    { 7, "Cream" },
                    { 8, "Cherry" },
                    { 9, "Floral" },
                    { 10, "Orange" },
                    { 11, "Pear" },
                    { 12, "Caramel" },
                    { 13, "Cacao" },
                    { 14, "Bold" },
                    { 15, "Pecan nut" },
                    { 16, "Walnut" },
                    { 17, "Rich" },
                    { 18, "Butterscotch" },
                    { 19, "Blackberry" },
                    { 20, "Honey" },
                    { 21, "Honeydew" },
                    { 22, "Crisp" },
                    { 23, "Lime" },
                    { 24, "Balanced" }
                });

            migrationBuilder.InsertData(
                table: "Coffees",
                columns: new[] { "Id", "CategoryId", "CertifiedOrganic", "Description", "ImageString", "Name", "Origin", "Price" },
                values: new object[,]
                {
                    { 1, 1, true, "A floral and chocolatey coffee straight from small farmers in northern Nicaragua. Light Roast.", "~/images/sku-1.webp", "Cantagallo", "Nicaragua", 20m },
                    { 2, 1, true, "A sweet, balanced blend of natural and wash-processed coffees creating one of our favorites. Light Roast.", "~/images/sku-2.webp", "La Flor", "Ethiopia Sidama, Mexico, Nicargua", 20m },
                    { 3, 2, false, "Deep in the Andes of Perú, the founding farmers of Pachamama grow exceptional organic coffee. Medium Roast.", "~/images/sku-3.webp", "Perú", "Santa Teresa, Cusco, Peru", 18.5m },
                    { 4, 2, true, "The northern mountains of Las Segovia, Nicaragua, are known for their quality coffee and strong cooperatives. Medium Roast.", "~/images/sku-4.webp", "Nicaragua", "Río Coco, Nicaragua", 18.5m },
                    { 5, 2, true, "In the volcanic highlands of Veracruz, México, the terroir is ideal for growing exceptional coffee. Medium Roast.", "~/images/sku-5.webp", "México", "Huatusco, Mexico", 19m },
                    { 6, 2, true, "Grown on the volcanic shores of Lago Atitlán, this is an exceptional single origin coffee from Guatemala. Medium Roast.", "~/images/sku-6.webp", "Guatemala", "Santa Clara, Guatemala", 20m },
                    { 7, 3, false, "A rich, bold and satisfying, our French Roast Blend is a great coffee for those that prefer a darker roast. French Roast.", "~/images/sku-7.webp", "French Roast", "Peru, Mexico, Nicaragua", 17.5m },
                    { 8, 3, true, "Our Decaf French Roast is Mountain Water Processed (MWP) in Mexico, without the use of chemicals. Dark Roast.", "~/images/sku-8.webp", "Decaf French", "Huatusco, Mexico", 19m },
                    { 9, 3, false, "Our darkest roast, a bold blend with a full body and rich flavor. Italian Roast.", "~/images/sku-9.webp", "Farmer's Blend", "Peru, Mexico, Nicaragua", 17.5m },
                    { 10, 1, true, "A fruity, natural processed coffee from the Sidama region. Light Roast.", "~/images/sku-10.webp", "Ethiopia Sidama Natural", "Sidama, Ethiopia", 25m },
                    { 11, 2, true, "Straight from the valley just below Machu Picchu, Perú, this single origin is roasted medium-dark. Vienna Roast.", "~/images/sku-11.webp", "Machu Picchu", "Santa Teresa, Cusco, Peru", 18.5m },
                    { 12, 1, false, "The blend formerly known as Breakfast, Sunrise is always a bright and uplifting start to the day. Light Roast.", "~/images/sku-12.webp", "Sunrise", "Guatemala, Peru, Nicaragua", 18.5m },
                    { 13, 3, false, "Pachamama's traditional, rich and bold roasted espresso blend. Full Roast.", "~/images/sku-13.webp", "Classic Espresso", "Ethiopia Sidama, Peru", 20m },
                    { 14, 2, false, "An all-time favorite and the perfect café de la casa, sure to please a crowd. Medium Roast.", "~/images/sku-14.webp", "Five Sisters", "Ethiopia Yirgacheffe, Guatemala", 19m },
                    { 15, 2, true, "Our Decaf Medium Roast is Mountain Water Processed (MWP) in Mexico, without the use of chemicals. Whole Beans.", "~/images/sku-15.webp", "Decaf México", "Huatusco, Mexico", 19.5m },
                    { 16, 2, false, "Celebrating our hometown Sacramento, a complex yet balanced blend of fruit forward coffees. Medium Roast.", "~/images/sku-16.webp", "Sactown", "Ethiopia Sidama, Ethiopia Yirgacheffe, Guatemala, Mexico", 21m },
                    { 17, 3, false, "A deep, smooth blend of natural and washed-processed coffee that's perfect for cold brewing. Full Roast.", "~/images/sku-17.webp", "Inca", "Ethiopia Sidama, Guatemala, Mexico", 20m },
                    { 18, 1, true, "A classic coffee from Yirgacheffe, crisp with layered complexity. Light Roast. Whole Beans.", "~/images/sku-18.webp", "Ethiopia Yirgacheffe", "Yirgacheffe, Ethiopia", 24m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Coffees",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6,
                oldScale: 2);
        }
    }
}

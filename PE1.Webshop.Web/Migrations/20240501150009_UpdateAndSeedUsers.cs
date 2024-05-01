using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PE1.Webshop.Web.Migrations
{
    public partial class UpdateAndSeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebOrders_Users_UserId",
                table: "WebOrders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WebOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$dyvCMtMhGS/DHnQch49TLw$htNUL6Jq5XgGQ+rc67dVDQ78VUkLlbzqRPbcJdMildU");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$IeA3QJKhGAC/O2Hpg6F3lA$Uvsm7Robb05mkO9OGF0AV6P+OCsOlc8i7fv+D800agM");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$uq0il56fy9RZbuOM7SmSPA$UDwpW6jjSm962EblbTxQ+9WNTHDYaDZAVjb8bzqSU1Q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$NrFTZki87uJcBbAyg6vSzA$nyOS/mjJZulLexj6Q29uU0QIanO3FyhC1qU1m3dreGs");

            migrationBuilder.AddForeignKey(
                name: "FK_WebOrders_Users_UserId",
                table: "WebOrders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebOrders_Users_UserId",
                table: "WebOrders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WebOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$AZ26gdOozqFflN1V/C9OaA$LfHdfUbRS8JG7VvOffeRzBJHuDlklZMmKVSDvnCVxQE");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$3UMUDAuPViOk7e/qD70NGg$o75wSp8Vy098hEaZkgmtn7TLMhrw5Pz2bmYZzK1cBWg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$aZjzZ73tUqgFTqxgBUoXWg$Eo7o6zCV4GMw4/JPqMQQMffBzYtGi7llbL/O7LCsPYs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PassWord",
                value: "$argon2id$v=19$m=65536,t=3,p=1$YFbYiraivXl/KAzsHXF4eQ$aDb1rKpE8YnbQR7GQGKUY7Dr7IixnTlG1Jf6JuSxRkA");

            migrationBuilder.AddForeignKey(
                name: "FK_WebOrders_Users_UserId",
                table: "WebOrders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

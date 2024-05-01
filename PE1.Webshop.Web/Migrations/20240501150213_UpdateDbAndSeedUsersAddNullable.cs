using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PE1.Webshop.Web.Migrations
{
    public partial class UpdateDbAndSeedUsersAddNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

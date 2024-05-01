using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PE1.Webshop.Web.Migrations
{
    public partial class UpdateDbAndSeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WebOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "PassWord", "UserName" },
                values: new object[,]
                {
                    { 1, "bart.soete@howest.be", "Bart", true, "Soete", "$argon2id$v=19$m=65536,t=3,p=1$AZ26gdOozqFflN1V/C9OaA$LfHdfUbRS8JG7VvOffeRzBJHuDlklZMmKVSDvnCVxQE", "bsoete" },
                    { 2, "johannes.dereuddre@ergens.be", "Johannes", true, "Dereuddre", "$argon2id$v=19$m=65536,t=3,p=1$3UMUDAuPViOk7e/qD70NGg$o75wSp8Vy098hEaZkgmtn7TLMhrw5Pz2bmYZzK1cBWg", "jders" },
                    { 3, "joe.mama@gmail.com", "Joe", false, "Mama", "$argon2id$v=19$m=65536,t=3,p=1$aZjzZ73tUqgFTqxgBUoXWg$Eo7o6zCV4GMw4/JPqMQQMffBzYtGi7llbL/O7LCsPYs", "joemama" },
                    { 4, "bob.bobbers@bob.be", "Bob", false, "Bobbers", "$argon2id$v=19$m=65536,t=3,p=1$YFbYiraivXl/KAzsHXF4eQ$aDb1rKpE8YnbQR7GQGKUY7Dr7IixnTlG1Jf6JuSxRkA", "bob" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebOrders_UserId",
                table: "WebOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WebOrders_Users_UserId",
                table: "WebOrders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebOrders_Users_UserId",
                table: "WebOrders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_WebOrders_UserId",
                table: "WebOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WebOrders");
        }
    }
}

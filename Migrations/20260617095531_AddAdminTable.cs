using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_web_Tatry.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Szlaki",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "Adminowie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HasloHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminowie", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Adminowie",
                columns: new[] { "Id", "HasloHash", "Login" },
                values: new object[] { 1, "$2a$11$/9SFaCYU2BPy/ywdyWiC/.uYWcnbhdsT6bU06K8GQC7miEQ9g2ifa", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminowie");

            migrationBuilder.InsertData(
                table: "Szlaki",
                columns: new[] { "Id", "CzasPrzejscia", "Dlugosc", "KolorSzlakow", "Nazwa", "Opis", "PoziomTrudnosci" },
                values: new object[] { 1, 2.5, 7.7999999999999998, "Czerwony", "Morskie Oko z Palenicy Białczańskiej", "Najpopularniejszy szlak w Tatrach, idealny dla rodzin z dziećmi. Prowadzi asfaltową drogą wzdłuż malowniczych potoków aż do schroniska nad największym tatrzańskim jeziorem.", "Łatwy" });
        }
    }
}

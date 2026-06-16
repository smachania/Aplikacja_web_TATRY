using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_web_Tatry.Migrations
{
    /// <inheritdoc />
    public partial class Innit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Szlaki",
                columns: new[] { "Id", "CzasPrzejscia", "Dlugosc", "KolorSzlakow", "Nazwa", "Opis", "PoziomTrudnosci" },
                values: new object[] { 1, 2.5, 7.7999999999999998, "Czerwony", "Morskie Oko z Palenicy Białczańskiej", "Najpopularniejszy szlak w Tatrach, idealny dla rodzin z dziećmi. Prowadzi asfaltową drogą wzdłuż malowniczych potoków aż do schroniska nad największym tatrzańskim jeziorem.", "Łatwy" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Szlaki",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

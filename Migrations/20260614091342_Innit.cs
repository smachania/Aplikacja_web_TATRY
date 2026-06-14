using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_web_Tatry.Migrations
{
    /// <inheritdoc />
    public partial class Innit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Szlaki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dlugosc = table.Column<double>(type: "float", nullable: false),
                    CzasPrzejscia = table.Column<double>(type: "float", nullable: false),
                    PoziomTrudnosci = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szlaki", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Szlaki");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_web_Tatry.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KolorSzlakow",
                table: "Szlaki",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Zdjecia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SciezkaPliku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SzlakId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zdjecia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zdjecia_Szlaki_SzlakId",
                        column: x => x.SzlakId,
                        principalTable: "Szlaki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zdjecia_SzlakId",
                table: "Zdjecia",
                column: "SzlakId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zdjecia");

            migrationBuilder.DropColumn(
                name: "KolorSzlakow",
                table: "Szlaki");
        }
    }
}

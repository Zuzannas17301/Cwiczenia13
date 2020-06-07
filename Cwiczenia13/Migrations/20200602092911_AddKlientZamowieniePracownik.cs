using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia13.Migrations
{
    public partial class AddKlientZamowieniePracownik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    IdKlient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.IdKlient);
                });

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.IdPracownik);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(nullable: false),
                    DataRealizacji = table.Column<DateTime>(nullable: false),
                    Uwagi = table.Column<string>(nullable: true),
                    IdKlient = table.Column<int>(nullable: false),
                    IdPracownik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Klient_IdKlient",
                        column: x => x.IdKlient,
                        principalTable: "Klient",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Pracownik_IdPracownik",
                        column: x => x.IdPracownik,
                        principalTable: "Pracownik",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdKlient",
                table: "Zamowienie",
                column: "IdKlient");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdPracownik",
                table: "Zamowienie",
                column: "IdPracownik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "Pracownik");
        }
    }
}

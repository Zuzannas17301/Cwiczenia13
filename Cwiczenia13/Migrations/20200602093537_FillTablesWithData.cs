using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia13.Migrations
{
    public partial class FillTablesWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Klient",
                columns: new[] { "IdKlient", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Agnieszka", "Poterek" },
                    { 2, "Kacper", "Kali" },
                    { 3, "Weronika", "Smardzik" },
                    { 4, "Monika", "Zajac" },
                    { 5, "Katarzyna", "Malec" }
                });

            migrationBuilder.InsertData(
                table: "Pracownik",
                columns: new[] { "IdPracownik", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Wojciech", "Wojdat" },
                    { 2, "Marcin", "Poniatowski" },
                    { 3, "Bartosz", "Buczek" },
                    { 4, "Jakub", "Malewski" },
                    { 5, "Anna", "Jantar" }
                });

            migrationBuilder.InsertData(
                table: "WyrobCukierniczy",
                columns: new[] { "IdWyrobuCukierniczego", "CenaZaSzt", "Nazwa", "Typ" },
                values: new object[,]
                {
                    { 1, 60f, "Beza Pavlova", "ciasto" },
                    { 2, 20f, "Karpatka", "ciasto" },
                    { 3, 15f, "Szarlotka", "ciasto" },
                    { 4, 1.5f, "Pączek", "deser" },
                    { 5, 35f, "Karmelowiec", "ciasto" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienie",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 2, 11, 35, 36, 909, DateTimeKind.Local).AddTicks(9249), 1, 1, "brak" },
                    { 2, new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 2, 11, 35, 36, 920, DateTimeKind.Local).AddTicks(3555), 2, 2, "brak" },
                    { 3, new DateTime(2020, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "sprawnie" },
                    { 6, new DateTime(2020, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 2, 11, 35, 36, 920, DateTimeKind.Local).AddTicks(3818), 1, 3, "" },
                    { 4, new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 2, 11, 35, 36, 920, DateTimeKind.Local).AddTicks(3773), 4, 4, "" },
                    { 7, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 2, 11, 35, 36, 920, DateTimeKind.Local).AddTicks(3836), 2, 4, "dlugo" },
                    { 5, new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 2, 11, 35, 36, 920, DateTimeKind.Local).AddTicks(3799), 5, 5, "" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "IdWyrobuCukierniczego", "IdZamowienia", "Ilosc", "Uwagi" },
                values: new object[,]
                {
                    { 1, 1, 1, "przechowywac w chlodzie" },
                    { 2, 2, 2, "" },
                    { 3, 3, 1, "" },
                    { 1, 6, 3, "" },
                    { 4, 4, 5, "" },
                    { 4, 7, 10, "tlusty czwartek" },
                    { 5, 5, 2, "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "WyrobCukierniczy",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WyrobCukierniczy",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WyrobCukierniczy",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WyrobCukierniczy",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WyrobCukierniczy",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "IdKlient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "IdKlient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "IdKlient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "IdKlient",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "IdKlient",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "IdPracownik",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "IdPracownik",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "IdPracownik",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "IdPracownik",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "IdPracownik",
                keyValue: 5);
        }
    }
}

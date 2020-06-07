using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia13.Migrations
{
    public partial class ChangedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Uwagi",
                table: "Zamowienie_WyrobCukierniczy",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Uwagi",
                table: "Zamowienie",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Typ",
                table: "WyrobCukierniczy",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "WyrobCukierniczy",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nazwisko",
                table: "Pracownik",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Imie",
                table: "Pracownik",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nazwisko",
                table: "Klient",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Imie",
                table: "Klient",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 1,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 6, 10, 4, 59, 918, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 2,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 6, 10, 4, 59, 922, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 4,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 6, 10, 4, 59, 922, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 5,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 6, 10, 4, 59, 922, DateTimeKind.Local).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 6,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 6, 10, 4, 59, 922, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 7,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 6, 10, 4, 59, 922, DateTimeKind.Local).AddTicks(2400));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Uwagi",
                table: "Zamowienie_WyrobCukierniczy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Uwagi",
                table: "Zamowienie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Typ",
                table: "WyrobCukierniczy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "WyrobCukierniczy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwisko",
                table: "Pracownik",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Imie",
                table: "Pracownik",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwisko",
                table: "Klient",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Imie",
                table: "Klient",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 1,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 2, 11, 35, 36, 909, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 2,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 2, 11, 35, 36, 920, DateTimeKind.Local).AddTicks(3555));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 4,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 2, 11, 35, 36, 920, DateTimeKind.Local).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 5,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 2, 11, 35, 36, 920, DateTimeKind.Local).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 6,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 2, 11, 35, 36, 920, DateTimeKind.Local).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 7,
                column: "DataRealizacji",
                value: new DateTime(2020, 6, 2, 11, 35, 36, 920, DateTimeKind.Local).AddTicks(3836));
        }
    }
}

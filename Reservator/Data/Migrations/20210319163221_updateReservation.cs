using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservator.Migrations
{
    public partial class updateReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowID",
                table: "Reservations",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statement",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isValide",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Statement",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "isValide",
                table: "Reservations");
        }
    }
}

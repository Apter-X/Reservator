using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservator.Migrations
{
    public partial class removeTimestampAndStsatement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Statement",
                table: "Reservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

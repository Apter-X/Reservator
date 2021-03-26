using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservator.Migrations
{
    public partial class renameTiemstamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Reservations",
                newName: "RowID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RowID",
                table: "Reservations",
                newName: "Timestamp");
        }
    }
}

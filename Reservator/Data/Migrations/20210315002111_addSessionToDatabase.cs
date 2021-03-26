using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservator.Migrations
{
    public partial class addSessionToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SessID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SessID",
                table: "Reservations",
                column: "SessID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Sessions_SessID",
                table: "Reservations",
                column: "SessID",
                principalTable: "Sessions",
                principalColumn: "SessionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Sessions_SessID",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_SessID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SessID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Reservations",
                newName: "RowID");

            migrationBuilder.AddColumn<bool>(
                name: "isValidate",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

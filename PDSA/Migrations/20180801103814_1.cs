using Microsoft.EntityFrameworkCore.Migrations;

namespace PDSA.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessUnitUnitID",
                table: "Processes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Processes_ProcessUnitUnitID",
                table: "Processes",
                column: "ProcessUnitUnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Units_ProcessUnitUnitID",
                table: "Processes",
                column: "ProcessUnitUnitID",
                principalTable: "Units",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Units_ProcessUnitUnitID",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_ProcessUnitUnitID",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "ProcessUnitUnitID",
                table: "Processes");
        }
    }
}

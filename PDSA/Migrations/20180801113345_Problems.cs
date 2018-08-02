using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PDSA.Migrations
{
    public partial class Problems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    ProblemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProcessID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.ProblemID);
                    table.ForeignKey(
                        name: "FK_Problems_Processes_ProcessID",
                        column: x => x.ProcessID,
                        principalTable: "Processes",
                        principalColumn: "ProcessID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Etiologi",
                columns: table => new
                {
                    EtiologiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProblemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiologi", x => x.EtiologiID);
                    table.ForeignKey(
                        name: "FK_Etiologi_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "ProblemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solution",
                columns: table => new
                {
                    SolutionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DoStartTime = table.Column<DateTime>(nullable: false),
                    DoEndTime = table.Column<DateTime>(nullable: false),
                    ProblemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solution", x => x.SolutionID);
                    table.ForeignKey(
                        name: "FK_Solution_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "ProblemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etiologi_ProblemID",
                table: "Etiologi",
                column: "ProblemID");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ProcessID",
                table: "Problems",
                column: "ProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_Solution_ProblemID",
                table: "Solution",
                column: "ProblemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etiologi");

            migrationBuilder.DropTable(
                name: "Solution");

            migrationBuilder.DropTable(
                name: "Problems");
        }
    }
}

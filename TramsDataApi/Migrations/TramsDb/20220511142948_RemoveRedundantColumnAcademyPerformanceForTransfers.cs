using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class RemoveRedundantColumnAcademyPerformanceForTransfers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademyPerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademyPerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

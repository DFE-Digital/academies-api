using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class RemoveRedundantColumnsForTransfers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyStage2PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "KeyStage4PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "KeyStage5PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "LatestOfstedJudgementAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "PupilNumbersAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeyStage2PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyStage4PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyStage5PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LatestOfstedJudgementAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PupilNumbersAdditionalInformation",
                schema: "sdd",
                table: "AcademyTransferProjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

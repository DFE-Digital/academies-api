using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AdditionalInformationPerAcademy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeyStage2PerformanceAdditionalInformation",
                schema: "sdd",
                table: "TransferringAcademies",
                nullable: true);
            
            migrationBuilder.AddColumn<string>(
                name: "KeyStage4PerformanceAdditionalInformation",
                schema: "sdd",
                table: "TransferringAcademies",
                nullable: true);
            
            migrationBuilder.AddColumn<string>(
                name: "KeyStage5PerformanceAdditionalInformation",
                schema: "sdd",
                table: "TransferringAcademies",
                nullable: true);
            
            migrationBuilder.AddColumn<string>(
                name: "LatestOfstedReportAdditionalInformation",
                schema: "sdd",
                table: "TransferringAcademies",
                nullable: true);
            
            migrationBuilder.AddColumn<string>(
                name: "PupilNumbersAdditionalInformation",
                schema: "sdd",
                table: "TransferringAcademies",
                nullable: true);

            migrationBuilder.Sql(
                @"Exec ('Update a set a.PupilNumbersAdditionalInformation = p.PupilNumbersAdditionalInformation, a.LatestOfstedReportAdditionalInformation = p.LatestOfstedJudgementAdditionalInformation, a.KeyStage2PerformanceAdditionalInformation = p.KeyStage2PerformanceAdditionalInformation, a.KeyStage4PerformanceAdditionalInformation = p.KeyStage4PerformanceAdditionalInformation, a.KeyStage5PerformanceAdditionalInformation = p.KeyStage5PerformanceAdditionalInformation from sdd.AcademyTransferProjects p inner join sdd.TransferringAcademies a on a.fk_AcademyTransferProjectId = p.id')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"Exec ('Update sdd.TransferringAcademies set PupilNumbersAdditionalInformation = null, LatestOfstedReportAdditionalInformation = null, KeyStage2PerformanceAdditionalInformation = null, KeyStage4PerformanceAdditionalInformation = null, KeyStage5PerformanceAdditionalInformation = null')");
            
            migrationBuilder.DropColumn(
                name: "KeyStage2PerformanceAdditionalInformation",
                schema: "sdd",
                table: "TransferringAcademies");

            migrationBuilder.DropColumn(
                name: "KeyStage4PerformanceAdditionalInformation",
                schema: "sdd",
                table: "TransferringAcademies");

            migrationBuilder.DropColumn(
                name: "KeyStage5PerformanceAdditionalInformation",
                schema: "sdd",
                table: "TransferringAcademies");

            migrationBuilder.DropColumn(
                name: "LatestOfstedReportAdditionalInformation",
                schema: "sdd",
                table: "TransferringAcademies");

            migrationBuilder.DropColumn(
                name: "PupilNumbersAdditionalInformation",
                schema: "sdd",
                table: "TransferringAcademies");
        }
    }
}

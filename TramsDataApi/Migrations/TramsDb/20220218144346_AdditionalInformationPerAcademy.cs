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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

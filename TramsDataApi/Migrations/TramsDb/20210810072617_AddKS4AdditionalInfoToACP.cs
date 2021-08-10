using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddKS4AdditionalInfoToACP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyStagePerformanceTablesAdditionalInformation",
                schema: "sdd",
                table: "AcademyConversionProject");

            migrationBuilder.AddColumn<string>(
                name: "KeyStage2PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyStage4PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyStage2PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyConversionProject");

            migrationBuilder.DropColumn(
                name: "KeyStage4PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyConversionProject");

            migrationBuilder.AddColumn<string>(
                name: "KeyStagePerformanceTablesAdditionalInformation",
                schema: "sdd",
                table: "AcademyConversionProject",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

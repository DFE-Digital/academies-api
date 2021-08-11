using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddKS5AdditionalInfoToACP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeyStage5PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyStage5PerformanceAdditionalInformation",
                schema: "sdd",
                table: "AcademyConversionProject");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddEqualitiesImpactAssessmentToTransferProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EqualitiesImpactAssessmentConsidered",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EqualitiesImpactAssessmentConsidered",
                schema: "sdd",
                table: "AcademyTransferProjects");
        }
    }
}

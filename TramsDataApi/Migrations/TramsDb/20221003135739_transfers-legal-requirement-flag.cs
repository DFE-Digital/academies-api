using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class transferslegalrequirementflag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LegalRequirementsSectionIsCompleted",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LegalRequirementsSectionIsCompleted",
                schema: "sdd",
                table: "AcademyTransferProjects");
        }
    }
}

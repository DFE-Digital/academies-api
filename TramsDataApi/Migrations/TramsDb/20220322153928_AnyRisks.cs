using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AnyRisks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AnyRisks",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherRisksFurtherSpecification",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OtherRisksShouldBeConsidered",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnyRisks",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "OtherRisksFurtherSpecification",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "OtherRisksShouldBeConsidered",
                schema: "sdd",
                table: "AcademyTransferProjects");
        }
    }
}

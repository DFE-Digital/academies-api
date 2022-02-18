using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class A2BApplyingSchoolAddDeficitFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolAdEqualitiesImpactAssessmentDetails",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SchoolCFYCapitalIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SchoolCFYRevenueIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SchoolNFYCapitalIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SchoolNFYRevenueIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SchoolPFYCapitalIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SchoolPFYRevenueIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolAdEqualitiesImpactAssessmentDetails",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolCFYCapitalIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolCFYRevenueIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolNFYCapitalIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolNFYRevenueIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolPFYCapitalIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolPFYRevenueIsDeficit",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");
        }
    }
}

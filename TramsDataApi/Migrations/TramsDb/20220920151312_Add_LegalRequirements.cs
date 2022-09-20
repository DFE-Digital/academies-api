using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class Add_LegalRequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Consultation",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiocesanConsent",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoundationConsent",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoverningBodyResolution",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LegalRequirementsSectionComplete",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consultation",
                schema: "sdd",
                table: "AcademyConversionProject");

            migrationBuilder.DropColumn(
                name: "DiocesanConsent",
                schema: "sdd",
                table: "AcademyConversionProject");

            migrationBuilder.DropColumn(
                name: "FoundationConsent",
                schema: "sdd",
                table: "AcademyConversionProject");

            migrationBuilder.DropColumn(
                name: "GoverningBodyResolution",
                schema: "sdd",
                table: "AcademyConversionProject");

            migrationBuilder.DropColumn(
                name: "LegalRequirementsSectionComplete",
                schema: "sdd",
                table: "AcademyConversionProject");
        }
    }
}

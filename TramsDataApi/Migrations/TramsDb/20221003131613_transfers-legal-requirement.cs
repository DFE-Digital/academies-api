using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class transferslegalrequirement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiocesanConsent",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoundationConsent",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrustAgreement",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiocesanConsent",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "FoundationConsent",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "TrustAgreement",
                schema: "sdd",
                table: "AcademyTransferProjects");
        }
    }
}

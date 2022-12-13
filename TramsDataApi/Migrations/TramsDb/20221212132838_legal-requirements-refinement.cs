using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class legalrequirementsrefinement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundationConsent",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "TrustAgreement",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.AddColumn<string>(
                name: "IncomingTrustAgreement",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutgoingTrustConsent",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncomingTrustAgreement",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "OutgoingTrustConsent",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.AddColumn<string>(
                name: "FoundationConsent",
                schema: "sdd",
                table: "AcademyTransferProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrustAgreement",
                schema: "sdd",
                table: "AcademyTransferProjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

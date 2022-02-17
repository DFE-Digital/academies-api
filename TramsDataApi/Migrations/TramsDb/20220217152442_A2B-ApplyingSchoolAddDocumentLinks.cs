using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class A2BApplyingSchoolAddDocumentLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedSchoolFields",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "UpdatedTrustFields",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.AddColumn<string>(
                name: "DiocesePermissionEvidenceDocumentLink",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoundationEvidenceDocumentLink",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoverningBodyConsentEvidenceDocumentLink",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiocesePermissionEvidenceDocumentLink",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "FoundationEvidenceDocumentLink",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "GoverningBodyConsentEvidenceDocumentLink",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedSchoolFields",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedTrustFields",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

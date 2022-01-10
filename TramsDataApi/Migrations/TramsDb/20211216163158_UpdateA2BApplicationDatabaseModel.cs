using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class UpdateA2BApplicationDatabaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "A2BApplication",
                schema: "sdd");

            migrationBuilder.CreateTable(
                name: "A2BApplication",
                schema: "sdd",
                columns: table => new
                {
                    ApplicationId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ApplicationType = table.Column<int>(nullable: true),
                    FormTrustProposedNameOfTrust = table.Column<string>(nullable: true),
                    ApplicationSubmitted = table.Column<bool>(nullable: true),
                    ApplicationLeadAuthorId = table.Column<string>(nullable: true),
                    ApplicationVersion = table.Column<string>(nullable: true),
                    ApplicationLeadAuthorName = table.Column<string>(nullable: true),
                    ApplicationRole = table.Column<string>(nullable: true),
                    ApplicationRoleOtherDescription = table.Column<string>(nullable: true),
                    ChangesToTrust = table.Column<int>(nullable: true),
                    ChangesToTrustExplained = table.Column<string>(nullable: true),
                    ChangesToLaGovernance = table.Column<int>(nullable: true),
                    ChangesToLaGovernanceExplained = table.Column<string>(nullable: true),
                    FormTrustOpeningDate = table.Column<DateTime>(nullable: true),
                    TrustApproverName = table.Column<string>(nullable: true),
                    TrustApproverEmail = table.Column<string>(nullable: true),
                    TrustId = table.Column<string>(nullable: true),
                    FormTrustReasonApprovalToConvertAsSat = table.Column<int>(nullable: true),
                    FormTrustReasonApprovedPerson = table.Column<string>(nullable: true),
                    FormTrustReasonForming = table.Column<string>(nullable: true),
                    FormTrustReasonVision = table.Column<string>(nullable: true),
                    FormTrustReasonGeoAreas = table.Column<string>(nullable: true),
                    FormTrustReasonFreedom = table.Column<string>(nullable: true),
                    FormTrustReasonImproveTeaching = table.Column<string>(nullable: true),
                    FormTrustPlanForGrowth = table.Column<string>(nullable: true),
                    FormTrustPlansForNoGrowth = table.Column<string>(nullable: true),
                    FormTrustGrowthPlansYesNo = table.Column<int>(nullable: true),
                    FormTrustImprovementSupport = table.Column<string>(nullable: true),
                    FormTrustImprovementStrategy = table.Column<string>(nullable: true),
                    FormTrustImprovementApprovedSponsor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplication", x => x.ApplicationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "A2BApplication",
                schema: "sdd");

            migrationBuilder.CreateTable(
                name: "A2BApplication",
                schema: "sdd",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ApplicationType = table.Column<string>(nullable: true),
                    FormTrustProposedNameOfTrust = table.Column<string>(nullable: true),
                    ApplicationSubmitted = table.Column<bool>(nullable: false),
                    ApplicationLeadAuthorId = table.Column<string>(nullable: true),
                    ApplicationVersion = table.Column<string>(nullable: true),
                    ApplicationLeadAuthorName = table.Column<string>(nullable: true),
                    ApplicationRole = table.Column<string>(nullable: true),
                    ApplicationRoleOtherDescription = table.Column<string>(nullable: true),
                    ChangesToTrust = table.Column<int>(nullable: true),
                    ChangesToTrustExplained = table.Column<string>(nullable: true),
                    ChangesToLaGovernance = table.Column<int>(nullable: true),
                    ChangesToLaGovernanceExplained = table.Column<string>(nullable: true),
                    FormTrustOpeningDate = table.Column<DateTime>(nullable: true),
                    TrustApproverName = table.Column<string>(nullable: true),
                    TrustApproverEmail = table.Column<string>(nullable: true),
                    TrustId = table.Column<string>(nullable: true),
                    FormTrustReasonApprovalToConvertAsSat = table.Column<int>(nullable: true),
                    FormTrustReasonApprovedPerson = table.Column<string>(nullable: true),
                    FormTrustReasonForming = table.Column<string>(nullable: true),
                    FormTrustReasonVision = table.Column<string>(nullable: true),
                    FormTrustReasonGeoAreas = table.Column<string>(nullable: true),
                    FormTrustReasonFreedom = table.Column<string>(nullable: true),
                    FormTrustReasonImproveTeaching = table.Column<string>(nullable: true),
                    FormTrustPlanForGrowth = table.Column<string>(nullable: true),
                    FormTrustPlansForNoGrowth = table.Column<string>(nullable: true),
                    FormTrustGrowthPlansYesNo = table.Column<int>(nullable: true),
                    FormTrustImprovementSupport = table.Column<string>(nullable: true),
                    FormTrustImprovementStrategy = table.Column<string>(nullable: true),
                    FormTrustImprovementApprovedSponsor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplication", x => x.ApplicationId);
                });
        }
    }
}

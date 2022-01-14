using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class UpdateA2BApplication : Migration
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
                    ApplicationStatusId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ApplicationType = table.Column<int>(nullable: true),
                    FormTrustProposedNameOfTrust = table.Column<string>(nullable: true),
                    ApplicationSubmitted = table.Column<bool>(nullable: true),
                    ApplicationLeadAuthorId = table.Column<string>(nullable: true),
                    ApplicationVersion = table.Column<string>(nullable: true),
                    ApplicationLeadAuthorName = table.Column<string>(nullable: true),
                    ApplicationLeadEmail = table.Column<string>(nullable: true),
                    ApplicationRole = table.Column<string>(nullable: true),
                    ApplicationRoleOtherDescription = table.Column<string>(nullable: true),
                    ChangesToTrust = table.Column<bool>(nullable: true),
                    ChangesToTrustExplained = table.Column<string>(nullable: true),
                    ChangesToLaGovernance = table.Column<bool>(nullable: true),
                    ChangesToLaGovernanceExplained = table.Column<string>(nullable: true),
                    FormTrustOpeningDate = table.Column<DateTime>(nullable: true),
                    TrustApproverName = table.Column<string>(nullable: true),
                    TrustApproverEmail = table.Column<string>(nullable: true),
                    TrustId = table.Column<string>(nullable: true),
                    FormTrustReasonApprovalToConvertAsSat = table.Column<bool>(nullable: true),
                    FormTrustReasonApprovedPerson = table.Column<string>(nullable: true),
                    FormTrustReasonForming = table.Column<string>(nullable: true),
                    FormTrustReasonVision = table.Column<string>(nullable: true),
                    FormTrustReasonGeoAreas = table.Column<string>(nullable: true),
                    FormTrustReasonFreedom = table.Column<string>(nullable: true),
                    FormTrustReasonImproveTeaching = table.Column<string>(nullable: true),
                    FormTrustPlanForGrowth = table.Column<string>(nullable: true),
                    FormTrustPlansForNoGrowth = table.Column<string>(nullable: true),
                    FormTrustGrowthPlansYesNo = table.Column<bool>(nullable: true),
                    FormTrustImprovementSupport = table.Column<string>(nullable: true),
                    FormTrustImprovementStrategy = table.Column<string>(nullable: true),
                    FormTrustImprovementApprovedSponsor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplication", x => x.ApplicationId);
                });
            
            migrationBuilder.AlterColumn<bool>(
                name: "KeyPersonFinancialDirector",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KeyPersonDateOfBirth",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "KeyPersonChairOfTrust",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "KeyPersonCeoExecutive",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                nullable: true);
            
            migrationBuilder.CreateTable(
                name: "A2BApplicationType",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplicationKeyPersons_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplication_ApplicationType",
                schema: "sdd",
                table: "A2BApplication",
                column: "ApplicationType");

            migrationBuilder.AddForeignKey(
                name: "FK_A2BApplication_A2BApplicationType_ApplicationType",
                schema: "sdd",
                table: "A2BApplication",
                column: "ApplicationType",
                principalSchema: "sdd",
                principalTable: "A2BApplicationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_A2BApplicationKeyPersons_A2BApplication_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                column: "ApplicationId",
                principalSchema: "sdd",
                principalTable: "A2BApplication",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "A2BApplicationType",
                columns: new[] {"Id", "Name"},
                values: new object[] {100000001, "JoinMat"});
                        
            migrationBuilder.InsertData(
                schema: "sdd",
                table: "A2BApplicationType",
                columns: new[] {"Id", "Name"},
                values: new object[] {907660000, "FormMat"});
                        
            migrationBuilder.InsertData(
                schema: "sdd",
                table: "A2BApplicationType",
                columns: new[] {"Id", "Name"},
                values: new object[] {907660001, "FormSat"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_A2BApplication_A2BApplicationType_ApplicationType",
                schema: "sdd",
                table: "A2BApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_A2BApplicationKeyPersons_A2BApplication_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons");

            migrationBuilder.DropTable(
                name: "A2BApplicationType",
                schema: "sdd");

            migrationBuilder.DropIndex(
                name: "IX_A2BApplicationKeyPersons_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons");

            migrationBuilder.DropIndex(
                name: "IX_A2BApplication_ApplicationType",
                schema: "sdd",
                table: "A2BApplication");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons");

            migrationBuilder.DropColumn(
                name: "ApplicationLeadEmail",
                schema: "sdd",
                table: "A2BApplication");

            migrationBuilder.DropColumn(
                name: "ApplicationStatusId",
                schema: "sdd",
                table: "A2BApplication");

            migrationBuilder.AlterColumn<string>(
                name: "KeyPersonFinancialDirector",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KeyPersonDateOfBirth",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KeyPersonChairOfTrust",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KeyPersonCeoExecutive",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);
            
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

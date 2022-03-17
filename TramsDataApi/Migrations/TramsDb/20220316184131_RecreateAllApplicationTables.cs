using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class RecreateAllApplicationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "A2BApplication",
                schema: "sdd",
                columns: table => new
                {
                    ApplicationId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ApplicationType = table.Column<string>(nullable: true),
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
                    FormTrustImprovementApprovedSponsor = table.Column<string>(nullable: true),
                    TrustId = table.Column<string>(nullable: true),
                    ApplicationStatusId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplication", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "A2BApplicationApplyingSchool",
                schema: "sdd",
                columns: table => new
                {
                    ApplyingSchoolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolDeclarationSignedById = table.Column<string>(nullable: true),
                    SchoolDeclarationSignedByName = table.Column<string>(nullable: true),
                    SchoolDeclarationBodyAgree = table.Column<bool>(nullable: true),
                    SchoolDeclarationTeacherChair = table.Column<bool>(nullable: true),
                    SchoolDeclarationSignedByEmail = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SchoolConversionReasonsForJoining = table.Column<string>(nullable: true),
                    SchoolConversionTargetDateDifferent = table.Column<bool>(nullable: true),
                    SchoolConversionTargetDateDate = table.Column<DateTime>(nullable: true),
                    SchoolConversionTargetDateExplained = table.Column<string>(nullable: true),
                    SchoolConversionChangeName = table.Column<bool>(nullable: true),
                    SchoolConversionChangeNameValue = table.Column<string>(nullable: true),
                    SchoolConversionContactHeadName = table.Column<string>(nullable: true),
                    SchoolConversionContactHeadEmail = table.Column<string>(nullable: true),
                    SchoolConversionContactHeadTel = table.Column<string>(nullable: true),
                    SchoolConversionContactChairName = table.Column<string>(nullable: true),
                    SchoolConversionContactChairEmail = table.Column<string>(nullable: true),
                    SchoolConversionContactChairTel = table.Column<string>(nullable: true),
                    SchoolConversionContactRole = table.Column<string>(nullable: true),
                    SchoolConversionMainContactOtherName = table.Column<string>(nullable: true),
                    SchoolConversionMainContactOtherEmail = table.Column<string>(nullable: true),
                    SchoolConversionMainContactOtherTelephone = table.Column<string>(nullable: true),
                    SchoolConversionMainContactOtherRole = table.Column<string>(nullable: true),
                    SchoolConversionApproverContactName = table.Column<string>(nullable: true),
                    SchoolConversionApproverContactEmail = table.Column<string>(nullable: true),
                    SchoolAdInspectedButReportNotPublished = table.Column<bool>(nullable: true),
                    SchoolAdInspectedReportNotPublishedExplain = table.Column<string>(nullable: true),
                    SchoolLaReorganization = table.Column<bool>(nullable: true),
                    SchoolLaReorganizationExplain = table.Column<string>(nullable: true),
                    SchoolLaClosurePlans = table.Column<bool>(nullable: true),
                    SchoolLaClosurePlansExplain = table.Column<string>(nullable: true),
                    SchoolPartOfFederation = table.Column<bool>(nullable: true),
                    SchoolAddFurtherInformation = table.Column<bool>(nullable: true),
                    SchoolFurtherInformation = table.Column<string>(nullable: true),
                    SchoolAdSchoolContributionToTrust = table.Column<string>(nullable: true),
                    SchoolAdSafeguarding = table.Column<bool>(nullable: true),
                    SchoolAdSafeguardingExplained = table.Column<string>(nullable: true),
                    SchoolSACREExemption = table.Column<bool>(nullable: true),
                    SchoolSACREExemptionEndDate = table.Column<DateTime>(nullable: true),
                    SchoolFaithSchool = table.Column<bool>(nullable: true),
                    SchoolFaithSchoolDioceseName = table.Column<string>(nullable: true),
                    SchoolSupportedFoundation = table.Column<bool>(nullable: true),
                    SchoolSupportedFoundationBodyName = table.Column<string>(nullable: true),
                    SchoolAdFeederSchools = table.Column<string>(nullable: true),
                    SchoolAdEqualitiesImpactAssessment = table.Column<bool>(nullable: true),
                    SchoolAdEqualitiesImpactAssessmentDetails = table.Column<string>(nullable: true),
                    SchoolPFYRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolPFYRevenueIsDeficit = table.Column<bool>(nullable: true),
                    SchoolPFYRevenueStatusExplained = table.Column<string>(nullable: true),
                    SchoolPFYCapitalForward = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolPFYCapitalIsDeficit = table.Column<bool>(nullable: true),
                    SchoolPFYCapitalForwardStatusExplained = table.Column<string>(nullable: true),
                    SchoolPFYEndDate = table.Column<DateTime>(nullable: true),
                    SchoolCFYRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolCFYRevenueIsDeficit = table.Column<bool>(nullable: true),
                    SchoolCFYRevenueStatusExplained = table.Column<string>(nullable: true),
                    SchoolCFYCapitalForward = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolCFYCapitalIsDeficit = table.Column<bool>(nullable: true),
                    SchoolCFYCapitalForwardStatusExplained = table.Column<string>(nullable: true),
                    SchoolCFYEndDate = table.Column<DateTime>(nullable: true),
                    SchoolNFYRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolNFYRevenueIsDeficit = table.Column<bool>(nullable: true),
                    SchoolNFYRevenueStatusExplained = table.Column<string>(nullable: true),
                    SchoolNFYCapitalForward = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolNFYCapitalIsDeficit = table.Column<bool>(nullable: true),
                    SchoolNFYCapitalForwardStatusExplained = table.Column<string>(nullable: true),
                    SchoolNFYEndDate = table.Column<DateTime>(nullable: true),
                    SchoolFinancialInvestigations = table.Column<bool>(nullable: true),
                    SchoolFinancialInvestigationsExplain = table.Column<string>(nullable: true),
                    SchoolFinancialInvestigationsTrustAware = table.Column<bool>(nullable: true),
                    SchoolCapacityYear1 = table.Column<int>(nullable: true),
                    SchoolCapacityYear2 = table.Column<int>(nullable: true),
                    SchoolCapacityYear3 = table.Column<int>(nullable: true),
                    SchoolCapacityAssumptions = table.Column<string>(nullable: true),
                    SchoolCapacityPublishedAdmissionsNumber = table.Column<int>(nullable: true),
                    SchoolBuildLandOwnerExplained = table.Column<string>(nullable: true),
                    SchoolBuildLandSharedFacilities = table.Column<bool>(nullable: true),
                    SchoolBuildLandSharedFacilitiesExplained = table.Column<string>(nullable: true),
                    SchoolBuildLandWorksPlanned = table.Column<bool>(nullable: true),
                    SchoolBuildLandWorksPlannedExplained = table.Column<string>(nullable: true),
                    SchoolBuildLandWorksPlannedDate = table.Column<DateTime>(nullable: true),
                    SchoolBuildLandGrants = table.Column<bool>(nullable: true),
                    SchoolBuildLandGrantsBody = table.Column<string>(nullable: true),
                    SchoolBuildLandPriorityBuildingProgramme = table.Column<bool>(nullable: true),
                    SchoolBuildLandFutureProgramme = table.Column<bool>(nullable: true),
                    SchoolBuildLandPFIScheme = table.Column<bool>(nullable: true),
                    SchoolBuildLandPFISchemeType = table.Column<string>(nullable: true),
                    SchoolConsultationStakeholders = table.Column<bool>(nullable: true),
                    SchoolConsultationStakeholdersConsult = table.Column<string>(nullable: true),
                    SchoolSupportGrantFundsPaidTo = table.Column<string>(nullable: true),
                    DiocesePermissionEvidenceDocumentLink = table.Column<string>(nullable: true),
                    FoundationEvidenceDocumentLink = table.Column<string>(nullable: true),
                    GoverningBodyConsentEvidenceDocumentLink = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationApplyingSchool", x => x.ApplyingSchoolId);
                    table.ForeignKey(
                        name: "FK_A2BApplicationApplyingSchool_A2BApplication_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "sdd",
                        principalTable: "A2BApplication",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "A2BApplicationKeyPersons",
                schema: "sdd",
                columns: table => new
                {
                    KeyPersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    KeyPersonDateOfBirth = table.Column<DateTime>(nullable: true),
                    KeyPersonBiography = table.Column<string>(nullable: true),
                    KeyPersonCeoExecutive = table.Column<bool>(nullable: true),
                    KeyPersonChairOfTrust = table.Column<bool>(nullable: true),
                    KeyPersonFinancialDirector = table.Column<bool>(nullable: true),
                    KeyPersonMember = table.Column<bool>(nullable: true),
                    KeyPersonOther = table.Column<bool>(nullable: true),
                    KeyPersonTrustee = table.Column<bool>(nullable: true),
                    ApplicationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationKeyPersons", x => x.KeyPersonId);
                    table.ForeignKey(
                        name: "FK_A2BApplicationKeyPersons_A2BApplication_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "sdd",
                        principalTable: "A2BApplication",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "A2BSchoolLease",
                schema: "sdd",
                columns: table => new
                {
                    SchoolLeaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolLeaseTerm = table.Column<string>(nullable: true),
                    SchoolLeaseRepaymentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchoolLeaseInterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchoolLeasePaymentToDate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchoolLeasePurpose = table.Column<string>(nullable: true),
                    SchoolLeaseValueOfAssets = table.Column<string>(nullable: true),
                    SchoolLeaseResponsibleForAssets = table.Column<string>(nullable: true),
                    ApplyingSchoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BSchoolLease", x => x.SchoolLeaseId);
                    table.ForeignKey(
                        name: "FK_A2BSchoolLease_A2BApplicationApplyingSchool_ApplyingSchoolId",
                        column: x => x.ApplyingSchoolId,
                        principalSchema: "sdd",
                        principalTable: "A2BApplicationApplyingSchool",
                        principalColumn: "ApplyingSchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "A2BSchoolLoan",
                schema: "sdd",
                columns: table => new
                {
                    SchoolLoanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolLoanPurpose = table.Column<string>(nullable: true),
                    SchoolLoanProvider = table.Column<string>(nullable: true),
                    SchoolLoanInterestRate = table.Column<string>(nullable: true),
                    SchoolLoanSchedule = table.Column<string>(nullable: true),
                    ApplyingSchoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BSchoolLoan", x => x.SchoolLoanId);
                    table.ForeignKey(
                        name: "FK_A2BSchoolLoan_A2BApplicationApplyingSchool_ApplyingSchoolId",
                        column: x => x.ApplyingSchoolId,
                        principalSchema: "sdd",
                        principalTable: "A2BApplicationApplyingSchool",
                        principalColumn: "ApplyingSchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplicationApplyingSchool_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplicationKeyPersons_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_A2BSchoolLease_ApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLease",
                column: "ApplyingSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_A2BSchoolLoan_ApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLoan",
                column: "ApplyingSchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "A2BApplicationKeyPersons",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BSchoolLease",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BSchoolLoan",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BApplicationApplyingSchool",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BApplication",
                schema: "sdd");
        }
    }
}

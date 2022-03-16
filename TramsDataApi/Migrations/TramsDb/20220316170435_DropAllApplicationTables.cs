using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class DropAllApplicationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "A2BApplicationKeyPersons",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BApplicationStatus",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BContributor",
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

            migrationBuilder.DropTable(
                name: "A2BApplicationType",
                schema: "sdd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "A2BApplicationStatus",
                schema: "sdd",
                columns: table => new
                {
                    ApplicationStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationStatus", x => x.ApplicationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "A2BApplicationType",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "A2BContributor",
                schema: "sdd",
                columns: table => new
                {
                    ContributorUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContributorAppIdTest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContributorUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BContributor", x => x.ContributorUserId);
                });
            
            migrationBuilder.CreateTable(
                name: "A2BApplication",
                schema: "sdd",
                columns: table => new
                {
                    ApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationLeadAuthorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationLeadAuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationLeadEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationRoleOtherDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationStatusId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationSubmitted = table.Column<bool>(type: "bit", nullable: true),
                    ApplicationType = table.Column<int>(type: "int", nullable: true),
                    ApplicationVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangesToLaGovernance = table.Column<bool>(type: "bit", nullable: true),
                    ChangesToLaGovernanceExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangesToTrust = table.Column<bool>(type: "bit", nullable: true),
                    ChangesToTrustExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustGrowthPlansYesNo = table.Column<bool>(type: "bit", nullable: true),
                    FormTrustImprovementApprovedSponsor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustImprovementStrategy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustImprovementSupport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustOpeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FormTrustPlanForGrowth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustPlansForNoGrowth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustProposedNameOfTrust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustReasonApprovalToConvertAsSat = table.Column<bool>(type: "bit", nullable: true),
                    FormTrustReasonApprovedPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustReasonForming = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustReasonFreedom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustReasonGeoAreas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustReasonImproveTeaching = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTrustReasonVision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrustApproverEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrustApproverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrustId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplication", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_A2BApplication_A2BApplicationType_ApplicationType",
                        column: x => x.ApplicationType,
                        principalSchema: "sdd",
                        principalTable: "A2BApplicationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "A2BApplicationApplyingSchool",
                schema: "sdd",
                columns: table => new
                {
                    ApplyingSchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A2BApplicationApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiocesePermissionEvidenceDocumentLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundationEvidenceDocumentLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoverningBodyConsentEvidenceDocumentLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAdEqualitiesImpactAssessment = table.Column<bool>(type: "bit", nullable: true),
                    SchoolAdEqualitiesImpactAssessmentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAdFeederSchools = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAdInspectedButReportNotPublished = table.Column<bool>(type: "bit", nullable: true),
                    SchoolAdInspectedReportNotPublishedExplain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAdSafeguarding = table.Column<bool>(type: "bit", nullable: true),
                    SchoolAdSafeguardingExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAdSchoolContributionToTrust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAddFurtherInformation = table.Column<bool>(type: "bit", nullable: true),
                    SchoolBuildLandFutureProgramme = table.Column<bool>(type: "bit", nullable: true),
                    SchoolBuildLandGrants = table.Column<bool>(type: "bit", nullable: true),
                    SchoolBuildLandGrantsBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolBuildLandOwnerExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolBuildLandPFIScheme = table.Column<bool>(type: "bit", nullable: true),
                    SchoolBuildLandPFISchemeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolBuildLandPriorityBuildingProgramme = table.Column<bool>(type: "bit", nullable: true),
                    SchoolBuildLandSharedFacilities = table.Column<bool>(type: "bit", nullable: true),
                    SchoolBuildLandSharedFacilitiesExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolBuildLandWorksPlanned = table.Column<bool>(type: "bit", nullable: true),
                    SchoolBuildLandWorksPlannedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolBuildLandWorksPlannedExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolCFYCapitalForward = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolCFYCapitalForwardStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolCFYCapitalIsDeficit = table.Column<bool>(type: "bit", nullable: true),
                    SchoolCFYEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolCFYRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolCFYRevenueIsDeficit = table.Column<bool>(type: "bit", nullable: true),
                    SchoolCFYRevenueStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolCapacityAssumptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolCapacityPublishedAdmissionsNumber = table.Column<int>(type: "int", nullable: true),
                    SchoolCapacityYear1 = table.Column<int>(type: "int", nullable: true),
                    SchoolCapacityYear2 = table.Column<int>(type: "int", nullable: true),
                    SchoolCapacityYear3 = table.Column<int>(type: "int", nullable: true),
                    SchoolConsultationStakeholders = table.Column<bool>(type: "bit", nullable: true),
                    SchoolConsultationStakeholdersConsult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionApproverContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionApproverContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionChangeName = table.Column<bool>(type: "bit", nullable: true),
                    SchoolConversionChangeNameValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactChairEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactChairName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactChairTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactHeadEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactHeadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactHeadTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionMainContactOtherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionMainContactOtherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionMainContactOtherRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionMainContactOtherTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionReasonsForJoining = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionTargetDateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolConversionTargetDateDifferent = table.Column<bool>(type: "bit", nullable: true),
                    SchoolConversionTargetDateExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolDeclarationBodyAgree = table.Column<bool>(type: "bit", nullable: true),
                    SchoolDeclarationSignedByEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolDeclarationSignedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolDeclarationSignedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolDeclarationTeacherChair = table.Column<bool>(type: "bit", nullable: true),
                    SchoolFaithSchool = table.Column<bool>(type: "bit", nullable: true),
                    SchoolFaithSchoolDioceseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolFinancialInvestigations = table.Column<bool>(type: "bit", nullable: true),
                    SchoolFinancialInvestigationsExplain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolFinancialInvestigationsTrustAware = table.Column<bool>(type: "bit", nullable: true),
                    SchoolFurtherInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLaClosurePlans = table.Column<bool>(type: "bit", nullable: true),
                    SchoolLaClosurePlansExplain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLaReorganization = table.Column<bool>(type: "bit", nullable: true),
                    SchoolLaReorganizationExplain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolNFYCapitalForward = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolNFYCapitalForwardStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolNFYCapitalIsDeficit = table.Column<bool>(type: "bit", nullable: true),
                    SchoolNFYEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolNFYRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolNFYRevenueIsDeficit = table.Column<bool>(type: "bit", nullable: true),
                    SchoolNFYRevenueStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolPFYCapitalForward = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolPFYCapitalForwardStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolPFYCapitalIsDeficit = table.Column<bool>(type: "bit", nullable: true),
                    SchoolPFYEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolPFYRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolPFYRevenueIsDeficit = table.Column<bool>(type: "bit", nullable: true),
                    SchoolPFYRevenueStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolPartOfFederation = table.Column<bool>(type: "bit", nullable: true),
                    SchoolSACREExemption = table.Column<bool>(type: "bit", nullable: true),
                    SchoolSACREExemptionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolSupportGrantFundsPaidTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolSupportedFoundation = table.Column<bool>(type: "bit", nullable: true),
                    SchoolSupportedFoundationBodyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationApplyingSchool", x => x.ApplyingSchoolId);
                    table.ForeignKey(
                        name: "FK_A2BApplicationApplyingSchool_A2BApplication_A2BApplicationApplicationId",
                        column: x => x.A2BApplicationApplicationId,
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
                    KeyPersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KeyPersonBiography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyPersonCeoExecutive = table.Column<bool>(type: "bit", nullable: true),
                    KeyPersonChairOfTrust = table.Column<bool>(type: "bit", nullable: true),
                    KeyPersonDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KeyPersonFinancialDirector = table.Column<bool>(type: "bit", nullable: true),
                    KeyPersonFinancialDirectorTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyPersonMember = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyPersonOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyPersonTrustee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    SchoolLeaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A2BApplicationApplyingSchoolApplyingSchoolId = table.Column<int>(type: "int", nullable: true),
                    ApplyingSchoolId = table.Column<int>(type: "int", nullable: false),
                    SchoolLeaseInterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchoolLeasePaymentToDate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchoolLeasePurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLeaseRepaymentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchoolLeaseResponsibleForAssets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLeaseTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLeaseValueOfAssets = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BSchoolLease", x => x.SchoolLeaseId);
                    table.ForeignKey(
                        name: "FK_A2BSchoolLease_A2BApplicationApplyingSchool_A2BApplicationApplyingSchoolApplyingSchoolId",
                        column: x => x.A2BApplicationApplyingSchoolApplyingSchoolId,
                        principalSchema: "sdd",
                        principalTable: "A2BApplicationApplyingSchool",
                        principalColumn: "ApplyingSchoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "A2BSchoolLoan",
                schema: "sdd",
                columns: table => new
                {
                    SchoolLoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A2BApplicationApplyingSchoolApplyingSchoolId = table.Column<int>(type: "int", nullable: true),
                    ApplyingSchoolId = table.Column<int>(type: "int", nullable: false),
                    SchoolLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SchoolLoanInterestRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLoanProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLoanPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLoanSchedule = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BSchoolLoan", x => x.SchoolLoanId);
                    table.ForeignKey(
                        name: "FK_A2BSchoolLoan_A2BApplicationApplyingSchool_A2BApplicationApplyingSchoolApplyingSchoolId",
                        column: x => x.A2BApplicationApplyingSchoolApplyingSchoolId,
                        principalSchema: "sdd",
                        principalTable: "A2BApplicationApplyingSchool",
                        principalColumn: "ApplyingSchoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplication_ApplicationType",
                schema: "sdd",
                table: "A2BApplication",
                column: "ApplicationType");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplicationApplyingSchool_A2BApplicationApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                column: "A2BApplicationApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplicationKeyPersons_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_A2BSchoolLease_A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLease",
                column: "A2BApplicationApplyingSchoolApplyingSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_A2BSchoolLoan_A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLoan",
                column: "A2BApplicationApplyingSchoolApplyingSchoolId");
        }
    }
}

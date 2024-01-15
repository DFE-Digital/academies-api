using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.Academies.Infrastructure.Migrations.Mstr
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mstr");

            migrationBuilder.CreateTable(
                name: "EducationEstablishmentTrust",
                schema: "mstr",
                columns: table => new
                {
                    SK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Trust = table.Column<int>(type: "int", nullable: false),
                    FK_EducationEstablishment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationEstablishmentTrust", x => x.SK);
                });

            migrationBuilder.CreateTable(
                name: "IfdPipeline",
                schema: "mstr",
                columns: table => new
                {
                    SK = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralDetailsURN = table.Column<string>(name: "General Details.URN", type: "nvarchar(max)", nullable: true),
                    DeliveryProcessPFI = table.Column<string>(name: "Delivery Process.PFI", type: "nvarchar(max)", nullable: true),
                    DeliveryProcessPAN = table.Column<string>(name: "Delivery Process.PAN", type: "nvarchar(max)", nullable: true),
                    ProjecttemplateinformationDeficit = table.Column<string>(name: "Project template information.Deficit?", type: "nvarchar(max)", nullable: true),
                    ProjecttemplateinformationViabilityissue = table.Column<string>(name: "Project template information.Viability issue?", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IfdPipeline", x => x.SK);
                });

            migrationBuilder.CreateTable(
                name: "Ref_EducationEstablishmentType",
                schema: "mstr",
                columns: table => new
                {
                    SK = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ref_EducationEstablishmentType", x => x.SK);
                });

            migrationBuilder.CreateTable(
                name: "Ref_LocalAuthority",
                schema: "mstr",
                columns: table => new
                {
                    SK = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ref_LocalAuthority", x => x.SK);
                });

            migrationBuilder.CreateTable(
                name: "Ref_TrustType",
                schema: "mstr",
                columns: table => new
                {
                    SK = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ref_TrustType", x => x.SK);
                });

            migrationBuilder.CreateTable(
                name: "EducationEstablishment",
                schema: "mstr",
                columns: table => new
                {
                    SK = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK_GIAS_URN = table.Column<int>(type: "int", nullable: true),
                    PK_CDM_ID = table.Column<long>(type: "bigint", nullable: true),
                    URN = table.Column<int>(type: "int", nullable: true),
                    FK_LocalAuthority = table.Column<long>(type: "bigint", nullable: true),
                    FK_EstablishmentType = table.Column<long>(type: "bigint", nullable: true),
                    FK_EstablishmentGroupType = table.Column<long>(type: "bigint", nullable: true),
                    FK_EstablishmentStatus = table.Column<long>(type: "bigint", nullable: true),
                    FK_Region = table.Column<long>(type: "bigint", nullable: true),
                    EstablishmentNumber = table.Column<int>(type: "int", nullable: true),
                    EstablishmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    MainPhone = table.Column<string>(name: "Main Phone", type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(name: "Address Line1", type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(name: "Address Line2", type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(name: "Address Line3", type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatutoryLowAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatutoryHighAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPupils = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfstedLastInspection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfstedRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(name: "Modified By", type: "nvarchar(max)", nullable: true),
                    TheincomedeprivationaffectingchildrenindexIDACIquintile = table.Column<int>(name: "The income deprivation affecting children index (IDACI) quintile", type: "int", nullable: true),
                    Numberofshortinspectionssincelastfullinspection = table.Column<int>(name: "Number of short inspections since last full inspection", type: "int", nullable: true),
                    Dateoflatestshortinspection = table.Column<DateTime>(name: "Date of latest short inspection", type: "datetime2", nullable: true),
                    Shortinspectionpublicationdate = table.Column<DateTime>(name: "Short inspection publication date", type: "datetime2", nullable: true),
                    Didthelatestshortinspectionconverttoafullinspection = table.Column<string>(name: "Did the latest short inspection convert to a full inspection?", type: "nvarchar(max)", nullable: true),
                    Shortinspectionoveralloutcome = table.Column<string>(name: "Short inspection overall outcome", type: "nvarchar(max)", nullable: true),
                    Numberofothersection8inspectionssincelastfullinspection = table.Column<int>(name: "Number of other section 8 inspections since last full inspection", type: "int", nullable: true),
                    Inspectiontype = table.Column<string>(name: "Inspection type", type: "nvarchar(max)", nullable: true),
                    Inspectionstartdate = table.Column<DateTime>(name: "Inspection start date", type: "datetime2", nullable: true),
                    Inspectionenddate = table.Column<DateTime>(name: "Inspection end date", type: "datetime2", nullable: true),
                    Publicationdate = table.Column<DateTime>(name: "Publication date", type: "datetime2", nullable: true),
                    Overalleffectiveness = table.Column<int>(name: "Overall effectiveness", type: "int", nullable: true),
                    Categoryofconcern = table.Column<string>(name: "Category of concern", type: "nvarchar(max)", nullable: true),
                    Earlyyearsprovisionwhereapplicable = table.Column<int>(name: "Early years provision (where applicable)", type: "int", nullable: true),
                    Effectivenessofleadershipandmanagement = table.Column<int>(name: "Effectiveness of leadership and management", type: "int", nullable: true),
                    Issafeguardingeffective = table.Column<string>(name: "Is safeguarding effective?", type: "nvarchar(max)", nullable: true),
                    Previousinspectionstartdate = table.Column<DateTime>(name: "Previous inspection start date", type: "datetime2", nullable: true),
                    Previousinspectionenddate = table.Column<DateTime>(name: "Previous inspection end date", type: "datetime2", nullable: true),
                    Previouspublicationdate = table.Column<DateTime>(name: "Previous publication date", type: "datetime2", nullable: true),
                    Previousfullinspectionoveralleffectiveness = table.Column<int>(name: "Previous full inspection overall effectiveness", type: "int", nullable: true),
                    Previouscategoryofconcern = table.Column<string>(name: "Previous category of concern", type: "nvarchar(max)", nullable: true),
                    Previousearlyyearsprovisionwhereapplicable = table.Column<int>(name: "Previous early years provision (where applicable)", type: "int", nullable: true),
                    Previousissafeguardingeffective = table.Column<string>(name: "Previous is safeguarding effective?", type: "nvarchar(max)", nullable: true),
                    HeadTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadPreferredJobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhaseOfEducation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentageFSM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UKPRN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReligiousCharacter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReligiousEthos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diocese = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonEstablishmentClosed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectLead = table.Column<string>(name: "Project Lead", type: "nvarchar(max)", nullable: true),
                    Parliamentaryconstituency = table.Column<string>(name: "Parliamentary constituency", type: "nvarchar(max)", nullable: true),
                    Qualityofeducation = table.Column<int>(name: "Quality of education", type: "int", nullable: true),
                    Behaviourandattitudes = table.Column<int>(name: "Behaviour and attitudes", type: "int", nullable: true),
                    Personaldevelopment = table.Column<int>(name: "Personal development", type: "int", nullable: true),
                    Sixthformprovisionwhereapplicable = table.Column<int>(name: "Sixth form provision (where applicable)", type: "int", nullable: true),
                    URNatCurrentfullinspection = table.Column<int>(name: "URN at Current full inspection", type: "int", nullable: true),
                    URNatPreviousfullinspection = table.Column<int>(name: "URN at Previous full inspection", type: "int", nullable: true),
                    URNatSection8inspection = table.Column<int>(name: "URN at Section 8 inspection", type: "int", nullable: true),
                    AdministrativeDistrict = table.Column<string>(name: "Administrative District", type: "nvarchar(max)", nullable: true),
                    RouteofProject = table.Column<string>(name: "Route of Project", type: "nvarchar(max)", nullable: true),
                    GORregion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SFSOTerritory = table.Column<string>(name: "SFSO Territory", type: "nvarchar(max)", nullable: true),
                    GiasLastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfBoys = table.Column<int>(type: "int", nullable: true),
                    NumberOfGirls = table.Column<int>(type: "int", nullable: true),
                    Diocesecode = table.Column<string>(name: "Diocese(code)", type: "nvarchar(max)", nullable: true),
                    GORregioncode = table.Column<string>(name: "GORregion(code)", type: "nvarchar(max)", nullable: true),
                    ReligiousCharactercode = table.Column<string>(name: "ReligiousCharacter(code)", type: "nvarchar(max)", nullable: true),
                    ParliamentaryConstituencycode = table.Column<string>(name: "ParliamentaryConstituency(code)", type: "nvarchar(max)", nullable: true),
                    PhaseOfEducationcode = table.Column<int>(name: "PhaseOfEducation(code)", type: "int", nullable: true),
                    SenUnitCapacity = table.Column<int>(type: "int", nullable: true),
                    SenUnitOnRoll = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationEstablishment", x => x.SK);
                    table.ForeignKey(
                        name: "FK_EducationEstablishment_Ref_EducationEstablishmentType_FK_EstablishmentType",
                        column: x => x.FK_EstablishmentType,
                        principalSchema: "mstr",
                        principalTable: "Ref_EducationEstablishmentType",
                        principalColumn: "SK");
                    table.ForeignKey(
                        name: "FK_EducationEstablishment_Ref_LocalAuthority_FK_LocalAuthority",
                        column: x => x.FK_LocalAuthority,
                        principalSchema: "mstr",
                        principalTable: "Ref_LocalAuthority",
                        principalColumn: "SK");
                });

            migrationBuilder.CreateTable(
                name: "Trust",
                schema: "mstr",
                columns: table => new
                {
                    SK = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_TrustType = table.Column<long>(type: "bigint", nullable: true),
                    FK_Region = table.Column<long>(type: "bigint", nullable: true),
                    FK_TrustBanding = table.Column<long>(type: "bigint", nullable: true),
                    FK_TrustStatus = table.Column<long>(type: "bigint", nullable: true),
                    GroupUID = table.Column<string>(name: "Group UID", type: "nvarchar(max)", nullable: false),
                    GroupID = table.Column<string>(name: "Group ID", type: "nvarchar(max)", nullable: true),
                    RID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompaniesHouseNumber = table.Column<string>(name: "Companies House Number", type: "nvarchar(max)", nullable: true),
                    ClosedDate = table.Column<DateTime>(name: "Closed Date", type: "datetime2", nullable: true),
                    TrustStatus = table.Column<string>(name: "Trust Status", type: "nvarchar(max)", nullable: true),
                    JoinedDate = table.Column<DateTime>(name: "Joined Date", type: "datetime2", nullable: true),
                    MainPhone = table.Column<string>(name: "Main Phone", type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(name: "Address Line1", type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(name: "Address Line2", type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(name: "Address Line3", type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrioritisedforReview = table.Column<string>(name: "Prioritised for Review", type: "nvarchar(max)", nullable: true),
                    CurrentSingleListGrouping = table.Column<string>(name: "Current Single List Grouping", type: "nvarchar(max)", nullable: true),
                    DateofGroupingDecision = table.Column<DateTime>(name: "Date of Grouping Decision", type: "datetime2", nullable: true),
                    DateEnteredOntoSingleList = table.Column<DateTime>(name: "Date Entered Onto Single List", type: "datetime2", nullable: true),
                    TrustReviewWriteUp = table.Column<string>(name: "Trust Review Write Up", type: "nvarchar(max)", nullable: true),
                    DateofTrustReviewMeeting = table.Column<DateTime>(name: "Date of Trust Review Meeting", type: "datetime2", nullable: true),
                    FollowUpLetterSent = table.Column<string>(name: "Follow Up Letter Sent", type: "nvarchar(max)", nullable: true),
                    DateActionPlannedFor = table.Column<DateTime>(name: "Date Action Planned For", type: "datetime2", nullable: true),
                    WIPSummaryGoesToMinister = table.Column<string>(name: "WIP Summary Goes To Minister", type: "nvarchar(max)", nullable: true),
                    ExternalGovernanceReviewDate = table.Column<DateTime>(name: "External Governance Review Date", type: "datetime2", nullable: true),
                    EfficiencyICFPReviewCompleted = table.Column<string>(name: "Efficiency ICFP Review Completed", type: "nvarchar(max)", nullable: true),
                    EfficiencyICFPReviewOther = table.Column<string>(name: "Efficiency ICFP Review Other", type: "nvarchar(max)", nullable: true),
                    LinkToWorkplaceForEfficiencyICFPReview = table.Column<string>(name: "Link To Workplace For Efficiency ICFP Review", type: "nvarchar(max)", nullable: true),
                    NumberInTrust = table.Column<int>(name: "Number In Trust", type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(name: "Modified By", type: "nvarchar(max)", nullable: true),
                    AMSDTerritory = table.Column<string>(name: "AMSD Territory", type: "nvarchar(max)", nullable: true),
                    LeadAMSDTerritory = table.Column<string>(name: "Lead AMSD Territory", type: "nvarchar(max)", nullable: true),
                    UKPRN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrustPerformanceAndRiskDateOfMeeting = table.Column<DateTime>(name: "Trust Performance And Risk Date Of Meeting", type: "datetime2", nullable: true),
                    UPIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Incorporatedonopendate = table.Column<DateTime>(name: "Incorporated on (open date)", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trust", x => x.SK);
                    table.ForeignKey(
                        name: "FK_Trust_Ref_TrustType_FK_TrustType",
                        column: x => x.FK_TrustType,
                        principalSchema: "mstr",
                        principalTable: "Ref_TrustType",
                        principalColumn: "SK");
                });

            migrationBuilder.InsertData(
                schema: "mstr",
                table: "Ref_EducationEstablishmentType",
                columns: new[] { "SK", "Code", "Name" },
                values: new object[,]
                {
                    { 224L, "35", "Free schools" },
                    { 228L, "18", "Further education" }
                });

            migrationBuilder.InsertData(
                schema: "mstr",
                table: "Ref_LocalAuthority",
                columns: new[] { "SK", "Code", "Name" },
                values: new object[,]
                {
                    { 1L, "202", "Barnsley" },
                    { 2L, "203", "Birmingham" },
                    { 3L, "204", "Bradford" }
                });

            migrationBuilder.InsertData(
                schema: "mstr",
                table: "Ref_TrustType",
                columns: new[] { "SK", "Code", "Name" },
                values: new object[,]
                {
                    { 30L, "06", "Multi-academy trust" },
                    { 32L, "10", "Single-academy trust" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationEstablishment_FK_EstablishmentType",
                schema: "mstr",
                table: "EducationEstablishment",
                column: "FK_EstablishmentType");

            migrationBuilder.CreateIndex(
                name: "IX_EducationEstablishment_FK_LocalAuthority",
                schema: "mstr",
                table: "EducationEstablishment",
                column: "FK_LocalAuthority");

            migrationBuilder.CreateIndex(
                name: "IX_Trust_FK_TrustType",
                schema: "mstr",
                table: "Trust",
                column: "FK_TrustType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationEstablishment",
                schema: "mstr");

            migrationBuilder.DropTable(
                name: "EducationEstablishmentTrust",
                schema: "mstr");

            migrationBuilder.DropTable(
                name: "IfdPipeline",
                schema: "mstr");

            migrationBuilder.DropTable(
                name: "Trust",
                schema: "mstr");

            migrationBuilder.DropTable(
                name: "Ref_EducationEstablishmentType",
                schema: "mstr");

            migrationBuilder.DropTable(
                name: "Ref_LocalAuthority",
                schema: "mstr");

            migrationBuilder.DropTable(
                name: "Ref_TrustType",
                schema: "mstr");
        }
    }
}

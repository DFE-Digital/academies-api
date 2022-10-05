using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class addConcernsDecisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcernsDecision",
                schema: "sdd",
                columns: table => new
                {
                    DecisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcernsCaseId = table.Column<int>(nullable: false),
                    TotalAmountRequested = table.Column<decimal>(type: "money", nullable: false),
                    SupportingNotes = table.Column<string>(nullable: true),
                    ReceivedRequestDate = table.Column<DateTimeOffset>(nullable: false),
                    SubmissionDocumentLink = table.Column<string>(nullable: true),
                    SubmissionRequired = table.Column<bool>(nullable: false),
                    RetrospectiveApproval = table.Column<bool>(nullable: false),
                    CrmCaseNumber = table.Column<string>(nullable: true),
                    CreatedAtDateTimeOffset = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAtDateTimeOffset = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsDecision", x => x.DecisionId);
                    table.ForeignKey(
                        name: "FK_ConcernsDecision_ConcernsCase_ConcernsCaseId",
                        column: x => x.ConcernsCaseId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsDecisionTypeId",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsDecisionTypeId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsDecisionType",
                schema: "sdd",
                columns: table => new
                {
                    DecisionTypeId = table.Column<int>(nullable: false),
                    DecisionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsDecisionType", x => new { x.DecisionId, x.DecisionTypeId });
                    table.ForeignKey(
                        name: "FK_ConcernsDecisionType_ConcernsDecision_DecisionId",
                        column: x => x.DecisionId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsDecision",
                        principalColumn: "DecisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsDecisionTypeId",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "NoticeToImprove" },
                    { 2, "Section128" },
                    { 3, "QualifiedFloatingCharge" },
                    { 4, "NonRepayableFinancialSupport" },
                    { 5, "RepayableFinancialSupport" },
                    { 6, "ShortTermCashAdvance" },
                    { 7, "WriteOffRecoverableFunding" },
                    { 8, "OtherFinancialSupport" },
                    { 9, "EstimatesFundingOrPupilNumberAdjustment" },
                    { 10, "EsfaApproval" },
                    { 11, "FreedomOfInformationExemptions" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsDecision_ConcernsCaseId",
                schema: "sdd",
                table: "ConcernsDecision",
                column: "ConcernsCaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcernsDecisionType",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsDecisionTypeId",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsDecision",
                schema: "sdd");
        }
    }
}

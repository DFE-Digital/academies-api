using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class addNTIWarningLetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NTIWarningLetterConditionType",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterConditionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterReason",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterStatus",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterCondition",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ConditionTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterCondition_NTIWarningLetterConditionType_ConditionTypeId",
                        column: x => x.ConditionTypeId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterCase",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseUrn = table.Column<int>(nullable: false),
                    DateLetterSent = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(maxLength: 2000, nullable: true),
                    ClosedStatusId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ClosedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterCase_NTIWarningLetterStatus_ClosedStatusId",
                        column: x => x.ClosedStatusId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterCase_NTIWarningLetterStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterConditionMapping",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NTIWarningLetterId = table.Column<long>(nullable: false),
                    NTIWarningLetterConditionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterConditionMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterConditionMapping_NTIWarningLetterCondition_NTIWarningLetterConditionId",
                        column: x => x.NTIWarningLetterConditionId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterConditionMapping_NTIWarningLetterCase_NTIWarningLetterId",
                        column: x => x.NTIWarningLetterId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterReasonMapping",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NTIWarningLetterId = table.Column<long>(nullable: false),
                    NTIWarningLetterReasonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterReasonMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterReasonMapping_NTIWarningLetterCase_NTIWarningLetterId",
                        column: x => x.NTIWarningLetterId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterReasonMapping_NTIWarningLetterReason_NTIWarningLetterReasonId",
                        column: x => x.NTIWarningLetterReasonId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterConditionType",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FinancialManagement", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Governance", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compliance", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Standard", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashFlowProblems", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CumulativeDeficitActual", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CumulativeDeficitProjected", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GovernanceConcerns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NonComplianceWithAcademiesFinancial", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NonComplianceWithFinancialReturns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "RiskOfInsolvency", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Safeguarding", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NoFurtherAction", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ToBeEscalated", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                columns: new[] { "Id", "ConditionTypeId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TrustFinancialPlan", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ActionPlan", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "LinesOfAccountability", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProvidingSufficientChallenge", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SchemeOfDelegation", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PublishingRequirements", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FinancialReturns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterCase_ClosedStatusId",
                schema: "sdd",
                table: "NTIWarningLetterCase",
                column: "ClosedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterCase_StatusId",
                schema: "sdd",
                table: "NTIWarningLetterCase",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterCondition_ConditionTypeId",
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                column: "ConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterConditionMapping_NTIWarningLetterConditionId",
                schema: "sdd",
                table: "NTIWarningLetterConditionMapping",
                column: "NTIWarningLetterConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterConditionMapping_NTIWarningLetterId",
                schema: "sdd",
                table: "NTIWarningLetterConditionMapping",
                column: "NTIWarningLetterId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterReasonMapping_NTIWarningLetterId",
                schema: "sdd",
                table: "NTIWarningLetterReasonMapping",
                column: "NTIWarningLetterId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterReasonMapping_NTIWarningLetterReasonId",
                schema: "sdd",
                table: "NTIWarningLetterReasonMapping",
                column: "NTIWarningLetterReasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NTIWarningLetterConditionMapping",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterReasonMapping",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterCondition",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterCase",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterReason",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterConditionType",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterStatus",
                schema: "sdd");
        }
    }
}

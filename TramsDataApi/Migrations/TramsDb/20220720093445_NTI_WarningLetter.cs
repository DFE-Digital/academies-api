using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class NTI_WarningLetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "sdd",
                table: "NTIUnderConsiderationStatus",
                nullable: true);

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
                    Description = table.Column<string>(nullable: true),
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

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash flow problems", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cumulative deficit (actual)", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cumulative deficit (projected)", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Governance concerns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-Compliance with Academies Financial/Trust Handbook", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-Compliance with financial returns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Risk of insolvency", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "No further action being taken", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warning letter or NTI can be set up using \"Add to case\".", "To be escalated", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterConditionType",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Financial management conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Standard conditions (Mandatory)", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compliance conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Governance conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 8, new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), "Safeguarding", new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) },
                    { 6, new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), "Non-Compliance with financial returns", new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) },
                    { 5, new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), "Non-Compliance with Academies Financial/Trust Handbook", new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) },
                    { 4, new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), "Governance concerns", new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) },
                    { 3, new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), "Cumulative deficit (projected)", new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) },
                    { 2, new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), "Cumulative deficit (actual)", new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) },
                    { 1, new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), "Cash flow problems", new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) },
                    { 7, new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), "Risk of insolvency", new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Preparing warning letter", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The warning letter is no longer needed.", "Cancel warning letter", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "You are satisfied that all the conditions have been, or will be, met as outlined in the letter", "Conditions met", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conditions have not been met. Close NTI: Warning letter and begin NTI on case page using \"Add to case\"", "Escalate to Notice To Improve", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sent to trust", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                columns: new[] { "Id", "ConditionTypeId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trust financial plan", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action plan", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lines of accountability", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Providing sufficient challenge", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scheme of delegation", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Publishing requirements (compliance with)", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Financial returns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "sdd",
                table: "NTIUnderConsiderationStatus");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashFlowProblems", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CumulativeDeficitActual", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CumulativeDeficitProjected", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "GovernanceConcerns", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "NonComplianceWithAcademiesFinancialTrustHandbook", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "NonComplianceWithFinancialReturns", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "RiskOfInsolvency", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "NoFurtherAction", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIUnderConsiderationStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "ToBeEscalated", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}

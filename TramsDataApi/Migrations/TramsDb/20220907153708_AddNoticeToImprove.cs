using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddNoticeToImprove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PastTenseName",
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NoticeToImproveConditionType",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveConditionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveReason",
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
                    table.PrimaryKey("PK_NoticeToImproveReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveStatus",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsClosingState = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveCondition",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ConditionTypeId = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveCondition_NoticeToImproveConditionType_ConditionTypeId",
                        column: x => x.ConditionTypeId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveCase",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseUrn = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    DateStarted = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(maxLength: 2000, nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ClosedAt = table.Column<DateTime>(nullable: true),
                    ClosedStatusId = table.Column<int>(nullable: true),
                    SumissionDecisionId = table.Column<string>(nullable: true),
                    DateNTILifted = table.Column<DateTime>(nullable: true),
                    DateNTIClosed = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveCase_NoticeToImproveStatus_ClosedStatusId",
                        column: x => x.ClosedStatusId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveCase_NoticeToImproveStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveConditionMapping",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticeToImproveId = table.Column<long>(nullable: false),
                    NoticeToImproveConditionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveConditionMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveConditionMapping_NoticeToImproveCondition_NoticeToImproveConditionId",
                        column: x => x.NoticeToImproveConditionId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveConditionMapping_NoticeToImproveCase_NoticeToImproveId",
                        column: x => x.NoticeToImproveId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveReasonMapping",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticeToImproveId = table.Column<long>(nullable: false),
                    NoticeToImproveReasonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveReasonMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveReasonMapping_NoticeToImproveCase_NoticeToImproveId",
                        column: x => x.NoticeToImproveId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveReasonMapping_NoticeToImproveReason_NoticeToImproveReasonId",
                        column: x => x.NoticeToImproveReasonId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "PastTenseName",
                value: "");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "PastTenseName",
                value: "");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "PastTenseName",
                value: "Conditions met");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "PastTenseName",
                value: "Conditions met");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "PastTenseName",
                value: "Conditions met");

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NoticeToImproveConditionType",
                columns: new[] { "Id", "CreatedAt", "DisplayOrder", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 7, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Additional Financial Support conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Financial management conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Fraud and irregularity", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Governance conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Compliance conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Safeguarding conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Standard conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NoticeToImproveReason",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash flow problems", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cumulative deficit (actual)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cumulative deficit (projected)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Governance concerns", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-compliance with Academies Financial/Trust Handbook", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-compliance with financial returns", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Risk of insolvency", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Safeguarding", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NoticeToImproveStatus",
                columns: new[] { "Id", "CreatedAt", "IsClosingState", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 10, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cancelled", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Closed", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Serious NTI breaches - considering escalation to TWN", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Submission to close NTI in progress", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Submission to lift NTI in progress", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Evidence of NTI non-compliance", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Progress on track", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Issued NTI", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Lifted", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Preparing NTI", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "SRMAReason",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "SchoolsFinancialSupportAndOversight");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "SRMAReason",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "RegionsGroupIntervention");

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NoticeToImproveCondition",
                columns: new[] { "Id", "ConditionTypeId", "CreatedAt", "DisplayOrder", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Audit and risk committee", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Excessive executive payments (high pay)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Publishing requirements (compliance with)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Related party Transactions (RPTs)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Review and update safeguarding policies", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Commission external review of safeguarding", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Appoint trustee with leadership responsibility for safeguarding", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Safeguarding recruitment process", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Admissions", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Novel, contentious, and/or repercussive transactions", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Procurement policy", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Register of interests", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 6, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Financial returns", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 6, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Delegated freedoms", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 6, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Trustee contact details", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Review of board and executive team capability", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Academy transfer (lower risk)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Off-payroll payments", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Move to latest model funding agreement", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Strengthen governance", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Scheme of delegation", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Internal audit findings", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Trust financial plan", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Financial management and governance review", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Financial systems & controls and internal scrutiny", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Integrated curriculum and financial planning", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Monthly management accounts", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "National deals for schools", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "School improvement", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "School resource management", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Academy transfer", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Action plan", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "AGM of members", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Board meetings", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Independant review of governance", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Lines of accountability", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Providing sufficient challenge", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Academy ambassadors", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Qualified Floating Charge (QFC)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveCase_ClosedStatusId",
                schema: "sdd",
                table: "NoticeToImproveCase",
                column: "ClosedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveCase_StatusId",
                schema: "sdd",
                table: "NoticeToImproveCase",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveCondition_ConditionTypeId",
                schema: "sdd",
                table: "NoticeToImproveCondition",
                column: "ConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveConditionMapping_NoticeToImproveConditionId",
                schema: "sdd",
                table: "NoticeToImproveConditionMapping",
                column: "NoticeToImproveConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveConditionMapping_NoticeToImproveId",
                schema: "sdd",
                table: "NoticeToImproveConditionMapping",
                column: "NoticeToImproveId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveReasonMapping_NoticeToImproveId",
                schema: "sdd",
                table: "NoticeToImproveReasonMapping",
                column: "NoticeToImproveId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveReasonMapping_NoticeToImproveReasonId",
                schema: "sdd",
                table: "NoticeToImproveReasonMapping",
                column: "NoticeToImproveReasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoticeToImproveConditionMapping",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveReasonMapping",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveCondition",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveCase",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveReason",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveConditionType",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveStatus",
                schema: "sdd");

            migrationBuilder.DropColumn(
                name: "PastTenseName",
                schema: "sdd",
                table: "NTIWarningLetterStatus");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "SRMAReason",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "AMSDIntervention");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "SRMAReason",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "RDDIntervention");
        }
    }
}

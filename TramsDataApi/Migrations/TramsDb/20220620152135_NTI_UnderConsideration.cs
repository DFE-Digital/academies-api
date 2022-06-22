using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class NTI_UnderConsideration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NTIUnderConsiderationReason",
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
                    table.PrimaryKey("PK_NTIUnderConsiderationReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NTIUnderConsiderationStatus",
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
                    table.PrimaryKey("PK_NTIUnderConsiderationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NTIUnderConsideration",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseUrn = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 2000, nullable: true),
                    CloseStatusId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ClosedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIUnderConsideration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIUnderConsideration_NTIUnderConsiderationStatus_CloseStatusId",
                        column: x => x.CloseStatusId,
                        principalSchema: "sdd",
                        principalTable: "NTIUnderConsiderationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NTIUnderConsiderationReasonMapping",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NTIUnderConsiderationId = table.Column<long>(nullable: false),
                    NTIUnderConsiderationReasonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIUnderConsiderationReasonMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIUnderConsiderationReasonMapping_NTIUnderConsideration_NTIUnderConsiderationId",
                        column: x => x.NTIUnderConsiderationId,
                        principalSchema: "sdd",
                        principalTable: "NTIUnderConsideration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NTIUnderConsiderationReasonMapping_NTIUnderConsiderationReason_NTIUnderConsiderationReasonId",
                        column: x => x.NTIUnderConsiderationReasonId,
                        principalSchema: "sdd",
                        principalTable: "NTIUnderConsiderationReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashFlowProblems", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CumulativeDeficitActual", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CumulativeDeficitProjected", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "GovernanceConcerns", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "NonComplianceWithAcademiesFinancialTrustHandbook", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "NonComplianceWithFinancialReturns", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "RiskOfInsolvency", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Safeguarding", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIUnderConsiderationStatus",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "NoFurtherAction", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "ToBeEscalated", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NTIUnderConsideration_CloseStatusId",
                schema: "sdd",
                table: "NTIUnderConsideration",
                column: "CloseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIUnderConsiderationReasonMapping_NTIUnderConsiderationId",
                schema: "sdd",
                table: "NTIUnderConsiderationReasonMapping",
                column: "NTIUnderConsiderationId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIUnderConsiderationReasonMapping_NTIUnderConsiderationReasonId",
                schema: "sdd",
                table: "NTIUnderConsiderationReasonMapping",
                column: "NTIUnderConsiderationReasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NTIUnderConsiderationReasonMapping",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIUnderConsideration",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIUnderConsiderationReason",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIUnderConsiderationStatus",
                schema: "sdd");
        }
    }
}

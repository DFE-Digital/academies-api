using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class FinancialPlanDataModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialPlanStatus",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPlanStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialPlanCase",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseUrn = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StatusId = table.Column<long>(nullable: true),
                    DatePlanRequested = table.Column<DateTime>(nullable: true),
                    DateViablePlanReceived = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPlanCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialPlanCase_FinancialPlanStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "sdd",
                        principalTable: "FinancialPlanStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "FinancialPlanStatus",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "AwaitingPlan", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ReturnToTrust", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ViablePlanReceived", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abandoned", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialPlanCase_StatusId",
                schema: "sdd",
                table: "FinancialPlanCase",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialPlanCase",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "FinancialPlanStatus",
                schema: "sdd");
        }
    }
}

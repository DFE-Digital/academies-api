using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class SRMA_AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SRMAReason",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Urn = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRMAReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SRMAStatus",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Urn = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRMAStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SRMACase",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Urn = table.Column<long>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    CloseStatusId = table.Column<int>(nullable: true),
                    ReasonId = table.Column<int>(nullable: true),
                    DateOffered = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DateAccepted = table.Column<DateTime>(nullable: true),
                    StartDateOfVisit = table.Column<DateTime>(nullable: true),
                    EndDateOfVisit = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ClosedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRMACase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SRMACase_ConcernsCase_CaseId",
                        column: x => x.CaseId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SRMACase_SRMAReason_ReasonId",
                        column: x => x.ReasonId,
                        principalSchema: "sdd",
                        principalTable: "SRMAReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SRMACase_CaseId",
                schema: "sdd",
                table: "SRMACase",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SRMACase_ReasonId",
                schema: "sdd",
                table: "SRMACase",
                column: "ReasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SRMACase",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "SRMAStatus",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "SRMAReason",
                schema: "sdd");
        }
    }
}

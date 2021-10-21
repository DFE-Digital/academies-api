using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddConcernsCaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "ConcernsGlobalSequence",
                minValue: 1L);

            migrationBuilder.CreateTable(
                name: "ConcernsStatus",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Urn = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CStatus__C5B214360AF620234", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsCase",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ReviewedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CrmEnquiry = table.Column<string>(nullable: true),
                    TrustUkprn = table.Column<string>(nullable: true),
                    ReasonForReview = table.Column<string>(nullable: true),
                    DeEscalation = table.Column<DateTime>(nullable: true),
                    Issue = table.Column<string>(nullable: true),
                    CurrentStatus = table.Column<string>(nullable: true),
                    CaseAim = table.Column<string>(nullable: true),
                    DeEscalationPoint = table.Column<string>(nullable: true),
                    NextSteps = table.Column<string>(nullable: true),
                    DirectionOfTravel = table.Column<string>(nullable: true),
                    Urn = table.Column<string>(nullable: true, defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence"),
                    fk_ConcernsStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CCase__C5B214360AF620234", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_fk_Status",
                        column: x => x.fk_ConcernsStatusId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsStatus",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 10, 20, 19, 14, 3, 879, DateTimeKind.Local).AddTicks(1210), "Live", new DateTime(2021, 10, 20, 19, 14, 3, 882, DateTimeKind.Local).AddTicks(1600) });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsStatus",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 10, 20, 19, 14, 3, 882, DateTimeKind.Local).AddTicks(2090), "Monitoring", new DateTime(2021, 10, 20, 19, 14, 3, 882, DateTimeKind.Local).AddTicks(2100) });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsStatus",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2021, 10, 20, 19, 14, 3, 882, DateTimeKind.Local).AddTicks(2110), "Close", new DateTime(2021, 10, 20, 19, 14, 3, 882, DateTimeKind.Local).AddTicks(2120) });

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsCase_fk_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase",
                column: "fk_ConcernsStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcernsCase",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsStatus",
                schema: "sdd");

            migrationBuilder.DropSequence(
                name: "ConcernsGlobalSequence");
        }
    }
}

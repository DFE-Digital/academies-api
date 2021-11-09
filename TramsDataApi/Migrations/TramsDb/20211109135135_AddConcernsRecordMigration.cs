using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddConcernsRecordMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcernsRecord",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ReviewAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    RatingId = table.Column<int>(nullable: false),
                    Primary = table.Column<bool>(nullable: false),
                    Urn = table.Column<string>(nullable: true, defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence"),
                    StatusUrn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsType",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Urn = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CType", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 225, DateTimeKind.Local).AddTicks(2040), new DateTime(2021, 11, 9, 13, 51, 35, 228, DateTimeKind.Local).AddTicks(260) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 228, DateTimeKind.Local).AddTicks(720), new DateTime(2021, 11, 9, 13, 51, 35, 228, DateTimeKind.Local).AddTicks(740) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 228, DateTimeKind.Local).AddTicks(750), new DateTime(2021, 11, 9, 13, 51, 35, 228, DateTimeKind.Local).AddTicks(750) });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsType",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(2950), "Financial reporting", "Compliance", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(3500) },
                    { 2, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(3970), "Financial returns", "Compliance", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(3990) },
                    { 3, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4000), "Deficit", "Financial", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4000) },
                    { 4, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4100), "Projected deficit / Low future surplus", "Financial", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4110) },
                    { 5, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4110), "Cash flow shortfall", "Financial", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4110) },
                    { 6, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4110), "Clawback", "Financial", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4110) },
                    { 7, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4120), null, "Force majeure", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4120) },
                    { 8, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4120), "Governance", "Governance", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4120) },
                    { 9, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4120), "Closure", "Governance", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130) },
                    { 10, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130), "Executive Pay", "Governance", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130) },
                    { 11, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130), "Safeguarding", "Governance", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130) },
                    { 12, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130), "Allegations and self reported concerns", "Irregularity", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4140) },
                    { 13, new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4140), "Related party transactions - in year", "Irregularity", new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4140) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcernsRecord",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsType",
                schema: "sdd");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 1, 15, 46, 15, 533, DateTimeKind.Local).AddTicks(3970), new DateTime(2021, 11, 1, 15, 46, 15, 536, DateTimeKind.Local).AddTicks(2910) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 1, 15, 46, 15, 536, DateTimeKind.Local).AddTicks(3380), new DateTime(2021, 11, 1, 15, 46, 15, 536, DateTimeKind.Local).AddTicks(3400) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 1, 15, 46, 15, 536, DateTimeKind.Local).AddTicks(3410), new DateTime(2021, 11, 1, 15, 46, 15, 536, DateTimeKind.Local).AddTicks(3410) });
        }
    }
}

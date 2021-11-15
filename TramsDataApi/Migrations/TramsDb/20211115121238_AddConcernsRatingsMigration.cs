using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddConcernsRatingsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcernsRating",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Urn = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CRating", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsRating",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(4800), "Red - Plus", new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(5570) },
                    { 2, new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6380), "Red", new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6400) },
                    { 3, new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6420), "Red - Amber", new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6420) },
                    { 4, new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6430), "Amber - Green", new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6430) },
                    { 5, new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6430), "n/a", new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6440) }
                });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 22, DateTimeKind.Local).AddTicks(4170), new DateTime(2021, 11, 15, 12, 12, 38, 25, DateTimeKind.Local).AddTicks(2510) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 25, DateTimeKind.Local).AddTicks(2970), new DateTime(2021, 11, 15, 12, 12, 38, 25, DateTimeKind.Local).AddTicks(2980) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 25, DateTimeKind.Local).AddTicks(2990), new DateTime(2021, 11, 15, 12, 12, 38, 25, DateTimeKind.Local).AddTicks(2990) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 48, DateTimeKind.Local).AddTicks(9850), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(450) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1470), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1510) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1520), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1520) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1520), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1520) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1530), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1530) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1530), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1530) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1530), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1540) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1540), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1540) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1540), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1540) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1540), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1550) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1550), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1550) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1550), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1550) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1560), new DateTime(2021, 11, 15, 12, 12, 38, 49, DateTimeKind.Local).AddTicks(1560) });

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsRecord_RatingId",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK__ConcernsRecord_ConcernsRating",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "RatingId",
                principalSchema: "sdd",
                principalTable: "ConcernsRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ConcernsRecord_ConcernsRating",
                schema: "sdd",
                table: "ConcernsRecord");

            migrationBuilder.DropTable(
                name: "ConcernsRating",
                schema: "sdd");

            migrationBuilder.DropIndex(
                name: "IX_ConcernsRecord_RatingId",
                schema: "sdd",
                table: "ConcernsRecord");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 815, DateTimeKind.Local).AddTicks(8250), new DateTime(2021, 11, 12, 14, 36, 57, 818, DateTimeKind.Local).AddTicks(7820) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 818, DateTimeKind.Local).AddTicks(8630), new DateTime(2021, 11, 12, 14, 36, 57, 818, DateTimeKind.Local).AddTicks(8650) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 818, DateTimeKind.Local).AddTicks(8660), new DateTime(2021, 11, 12, 14, 36, 57, 818, DateTimeKind.Local).AddTicks(8660) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1060), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1450) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1840), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1850) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1860), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1860) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1860), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1860) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1870), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1870) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1870), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1870) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1870), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1870) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1880), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1880) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1880), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1880) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1880), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1880) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1950), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1950) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1960), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1960) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1960), new DateTime(2021, 11, 12, 14, 36, 57, 828, DateTimeKind.Local).AddTicks(1960) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class UpdateConcernsRatingsNameDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 561, DateTimeKind.Local).AddTicks(9490), "Red-Plus", new DateTime(2021, 11, 17, 14, 54, 28, 561, DateTimeKind.Local).AddTicks(9900) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 562, DateTimeKind.Local).AddTicks(300), new DateTime(2021, 11, 17, 14, 54, 28, 562, DateTimeKind.Local).AddTicks(310) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 562, DateTimeKind.Local).AddTicks(320), "Red-Amber", new DateTime(2021, 11, 17, 14, 54, 28, 562, DateTimeKind.Local).AddTicks(320) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 562, DateTimeKind.Local).AddTicks(330), "Amber-Green", new DateTime(2021, 11, 17, 14, 54, 28, 562, DateTimeKind.Local).AddTicks(330) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 562, DateTimeKind.Local).AddTicks(330), new DateTime(2021, 11, 17, 14, 54, 28, 562, DateTimeKind.Local).AddTicks(330) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 537, DateTimeKind.Local).AddTicks(3100), new DateTime(2021, 11, 17, 14, 54, 28, 540, DateTimeKind.Local).AddTicks(7330) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 540, DateTimeKind.Local).AddTicks(7820), new DateTime(2021, 11, 17, 14, 54, 28, 540, DateTimeKind.Local).AddTicks(7840) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 540, DateTimeKind.Local).AddTicks(7840), new DateTime(2021, 11, 17, 14, 54, 28, 540, DateTimeKind.Local).AddTicks(7850) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(4330), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(4820) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5320), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5340) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5360), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5360) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5360), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5360) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5370), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5370) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5370), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5370) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5380), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5380) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5380), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5380) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5390), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5390) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5390), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5390) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5400), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5400) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5400), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5400) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5410), new DateTime(2021, 11, 17, 14, 54, 28, 560, DateTimeKind.Local).AddTicks(5410) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(4800), "Red - Plus", new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(5570) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6380), new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6400) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6420), "Red - Amber", new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6430), "Amber - Green", new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6430) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6430), new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6440) });

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
        }
    }
}

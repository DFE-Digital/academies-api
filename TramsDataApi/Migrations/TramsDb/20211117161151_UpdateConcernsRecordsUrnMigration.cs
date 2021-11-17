using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class UpdateConcernsRecordsUrnMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Urn",
                schema: "sdd",
                table: "ConcernsRecord",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(2270), new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(2680) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3070), new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3080) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3090), new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3090) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3090), new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3100) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3100), new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3100) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 649, DateTimeKind.Local).AddTicks(4020), new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(4920) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5410), new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5420) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5430), new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5440) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(8240), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(8650) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9060), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9080), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9080) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9080), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Urn",
                schema: "sdd",
                table: "ConcernsRecord",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence",
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(4800), new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(5570) });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6420), new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6430), new DateTime(2021, 11, 15, 12, 12, 38, 51, DateTimeKind.Local).AddTicks(6430) });

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

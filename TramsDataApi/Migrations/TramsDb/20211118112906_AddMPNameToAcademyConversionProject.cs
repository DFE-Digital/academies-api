using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddMPNameToAcademyConversionProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberOfParliamentName",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(8584), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(8897) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(9187), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(9203) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(9213), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(9215) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(9218), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(9221) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(9223), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(9226) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 842, DateTimeKind.Local).AddTicks(9661), new DateTime(2021, 11, 18, 11, 29, 5, 845, DateTimeKind.Local).AddTicks(4658) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 845, DateTimeKind.Local).AddTicks(5029), new DateTime(2021, 11, 18, 11, 29, 5, 845, DateTimeKind.Local).AddTicks(5047) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 845, DateTimeKind.Local).AddTicks(5055), new DateTime(2021, 11, 18, 11, 29, 5, 845, DateTimeKind.Local).AddTicks(5058) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(855), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1163) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1449), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1466) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1475), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1477) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1480), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1483) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1486), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1488) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1491), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1493) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1496), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1498) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1501), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1503) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1506), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1509) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1511), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1514) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1517), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1519) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1522), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1524) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1527), new DateTime(2021, 11, 18, 11, 29, 5, 852, DateTimeKind.Local).AddTicks(1529) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberOfParliamentName",
                schema: "sdd",
                table: "AcademyConversionProject");

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

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class CreateConcernsMeansOfReferral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcernsMeansOfReferral",
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
                    table.PrimaryKey("PK__CMeansOfReferral", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsMeansOfReferral",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ESFA activity, TFFT or other departmental activity", "Internal", new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CIU casework, whistleblowing, self reported, RSCs or other government bodies", "External", new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473), new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473), new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473), new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473), new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473), new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473), new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473), new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473), new DateTime(2022, 7, 28, 12, 15, 27, 562, DateTimeKind.Local).AddTicks(473) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcernsMeansOfReferral",
                schema: "sdd");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) });
        }
    }
}

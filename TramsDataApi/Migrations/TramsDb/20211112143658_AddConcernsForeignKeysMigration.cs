using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddConcernsForeignKeysMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcernsCase_ConcernsStatus_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.DropIndex(
                name: "IX_ConcernsCase_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.DropColumn(
                name: "ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.AlterColumn<int>(
                name: "Urn",
                schema: "sdd",
                table: "ConcernsCase",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence");

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

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsRecord_CaseId",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsRecord_TypeId",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK__ConcernsCase_ConcernsRecord",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "CaseId",
                principalSchema: "sdd",
                principalTable: "ConcernsCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__ConcernsRecord_ConcernsType",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "TypeId",
                principalSchema: "sdd",
                principalTable: "ConcernsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ConcernsCase_ConcernsRecord",
                schema: "sdd",
                table: "ConcernsRecord");

            migrationBuilder.DropForeignKey(
                name: "FK__ConcernsRecord_ConcernsType",
                schema: "sdd",
                table: "ConcernsRecord");

            migrationBuilder.DropIndex(
                name: "IX_ConcernsRecord_CaseId",
                schema: "sdd",
                table: "ConcernsRecord");

            migrationBuilder.DropIndex(
                name: "IX_ConcernsRecord_TypeId",
                schema: "sdd",
                table: "ConcernsRecord");

            migrationBuilder.AlterColumn<string>(
                name: "Urn",
                schema: "sdd",
                table: "ConcernsCase",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence",
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence");

            migrationBuilder.AddColumn<int>(
                name: "ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase",
                type: "int",
                nullable: true);

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

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(2950), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(3500) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(3970), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(3990) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4000), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4000) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4100), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4110) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4110), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4110) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4110), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4110) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4120), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4120) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4120), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4120) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4120), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4130), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4140) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4140), new DateTime(2021, 11, 9, 13, 51, 35, 232, DateTimeKind.Local).AddTicks(4140) });

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsCase_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase",
                column: "ConcernsStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcernsCase_ConcernsStatus_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase",
                column: "ConcernsStatusId",
                principalSchema: "sdd",
                principalTable: "ConcernsStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

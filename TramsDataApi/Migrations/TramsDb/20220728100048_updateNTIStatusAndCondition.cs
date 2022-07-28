using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class updateNTIStatusAndCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosingState",
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                schema: "sdd",
                table: "NTIWarningLetterConditionType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                keyColumn: "Id",
                keyValue: 1,
                column: "DisplayOrder",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                keyColumn: "Id",
                keyValue: 2,
                column: "DisplayOrder",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                keyColumn: "Id",
                keyValue: 3,
                column: "DisplayOrder",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                keyColumn: "Id",
                keyValue: 4,
                column: "DisplayOrder",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                keyColumn: "Id",
                keyValue: 5,
                column: "DisplayOrder",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                keyColumn: "Id",
                keyValue: 6,
                column: "DisplayOrder",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                keyColumn: "Id",
                keyValue: 7,
                column: "DisplayOrder",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterConditionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "DisplayOrder",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterConditionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "DisplayOrder",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterConditionType",
                keyColumn: "Id",
                keyValue: 3,
                column: "DisplayOrder",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterConditionType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DisplayOrder", "Name" },
                values: new object[] { 4, "Standard conditions (mandatory)" });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-compliance with Academies Financial/Trust Handbook", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-compliance with financial returns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsClosingState",
                value: true);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsClosingState",
                value: true);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "IsClosingState" },
                values: new object[] { "Conditions have not been met. Close NTI: Warning letter and begin NTI on case page using \"Add to case\".", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosingState",
                schema: "sdd",
                table: "NTIWarningLetterStatus");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                schema: "sdd",
                table: "NTIWarningLetterConditionType");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                schema: "sdd",
                table: "NTIWarningLetterCondition");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterConditionType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Standard conditions (Mandatory)");

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
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), "Non-Compliance with Academies Financial/Trust Handbook", new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070), "Non-Compliance with financial returns", new DateTime(2022, 7, 20, 10, 34, 44, 985, DateTimeKind.Local).AddTicks(9070) });

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

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Conditions have not been met. Close NTI: Warning letter and begin NTI on case page using \"Add to case\"");
        }
    }
}

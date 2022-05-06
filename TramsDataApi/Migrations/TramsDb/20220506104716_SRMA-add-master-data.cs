using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class SRMAaddmasterdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "sdd",
                table: "SRMAReason",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "Urn" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "OfferLinked", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMSDIntervention", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "RDDIntervention", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "SRMAStatus",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "Urn" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "TrustConsidering", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "PreparingForDeployment", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deployed", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Declined", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canceled", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "sdd",
                table: "SRMAReason",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "sdd",
                table: "SRMAReason",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "sdd",
                table: "SRMAReason",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "sdd",
                table: "SRMAStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "sdd",
                table: "SRMAStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "sdd",
                table: "SRMAStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "sdd",
                table: "SRMAStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "sdd",
                table: "SRMAStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "sdd",
                table: "SRMAStatus",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}

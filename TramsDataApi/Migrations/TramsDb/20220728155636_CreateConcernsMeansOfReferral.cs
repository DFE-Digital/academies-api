using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class CreateConcernsMeansOfReferral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeansOfReferralId",
                schema: "sdd",
                table: "ConcernsRecord",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsRecord_MeansOfReferralId",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "MeansOfReferralId");

            migrationBuilder.AddForeignKey(
                name: "FK__ConcernsRecord_ConcernsMeansOfReferral",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "MeansOfReferralId",
                principalSchema: "sdd",
                principalTable: "ConcernsMeansOfReferral",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ConcernsRecord_ConcernsMeansOfReferral",
                schema: "sdd",
                table: "ConcernsRecord");

            migrationBuilder.DropTable(
                name: "ConcernsMeansOfReferral",
                schema: "sdd");

            migrationBuilder.DropIndex(
                name: "IX_ConcernsRecord_MeansOfReferralId",
                schema: "sdd",
                table: "ConcernsRecord");

            migrationBuilder.DropColumn(
                name: "MeansOfReferralId",
                schema: "sdd",
                table: "ConcernsRecord");
       }
    }
}

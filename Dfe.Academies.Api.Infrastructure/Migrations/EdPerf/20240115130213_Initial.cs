using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.Academies.Infrastructure.Migrations.EdPerf
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "edperf");

            migrationBuilder.CreateTable(
                name: "download_PUPILABSENCE_england_ALL",
                schema: "edperf",
                columns: table => new
                {
                    DownloadYear = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LA = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ESTAB = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    URN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateAndTimeImported = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PERCTOT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PPERSABS10 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_download_PUPILABSENCE_england_ALL", x => new { x.DownloadYear, x.URN, x.LA, x.ESTAB });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "download_PUPILABSENCE_england_ALL",
                schema: "edperf");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddDbGeneratedIdColumnToA2BApplicationKeyPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "A2BApplicationKeyPersons",
                schema: "sdd");
            
            migrationBuilder.CreateTable(
                name: "A2BApplicationKeyPersons",
                schema: "sdd",
                columns: table => new
                {
                    KeyPersonId = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    KeyPersonDateOfBirth = table.Column<string>(nullable: true),
                    KeyPersonBiography = table.Column<string>(nullable: true),
                    KeyPersonCeoExecutive = table.Column<string>(nullable: true),
                    KeyPersonChairOfTrust = table.Column<string>(nullable: true),
                    KeyPersonFinancialDirector = table.Column<string>(nullable: true),
                    KeyPersonFinancialDirectorTime = table.Column<string>(nullable: true),
                    KeyPersonMember = table.Column<string>(nullable: true),
                    KeyPersonOther = table.Column<string>(nullable: true),
                    KeyPersonTrustee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationKeyPersons", x => x.KeyPersonId);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "A2BApplication",
                schema: "sdd");

            migrationBuilder.CreateTable(
                name: "A2BApplicationKeyPersons",
                schema: "sdd",
                columns: table => new
                {
                    KeyPersonId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    KeyPersonDateOfBirth = table.Column<string>(nullable: true),
                    KeyPersonBiography = table.Column<string>(nullable: true),
                    KeyPersonCeoExecutive = table.Column<string>(nullable: true),
                    KeyPersonChairOfTrust = table.Column<string>(nullable: true),
                    KeyPersonFinancialDirector = table.Column<string>(nullable: true),
                    KeyPersonFinancialDirectorTime = table.Column<string>(nullable: true),
                    KeyPersonMember = table.Column<string>(nullable: true),
                    KeyPersonOther = table.Column<string>(nullable: true),
                    KeyPersonTrustee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationKeyPersons", x => x.KeyPersonId);
                });
        }
    }
}

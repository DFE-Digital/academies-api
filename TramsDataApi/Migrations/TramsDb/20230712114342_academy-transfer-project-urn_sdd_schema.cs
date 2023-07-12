using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class academytransferprojecturn_sdd_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {          
            migrationBuilder.CreateSequence<int>(
                name: "sequence_AcademyTransferProjectUrn",
                schema: "sdd",
                startValue: 10003000L,
                minValue: 10003000L);

            migrationBuilder.AlterColumn<int>(
                name: "Urn",
                schema: "sdd",
                table: "AcademyTransferProjects",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR sdd.sequence_AcademyTransferProjectUrn",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR AcademyTransferProjectUrns");                    
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Urn",
                schema: "sdd",
                table: "AcademyTransferProjects",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR AcademyTransferProjectUrns",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR sdd.sequence_AcademyTransferProjectUrn");

           migrationBuilder.DropSequence(
                name: "sequence_AcademyTransferProjectUrn",
                schema: "sdd");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
   public partial class projectcreatedondate : Migration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.AddColumn<DateTime>(
            "CreatedOn",
            schema: "sdd",
            table: "AcademyTransferProjects",
            nullable: false,
            defaultValueSql: "GETDATE()");
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropColumn(
            "CreatedOn",
            schema: "sdd",
            table: "AcademyTransferProjects");
      }
   }
}

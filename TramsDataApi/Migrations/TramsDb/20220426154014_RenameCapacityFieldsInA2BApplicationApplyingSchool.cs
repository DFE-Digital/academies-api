using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class RenameCapacityFieldsInA2BApplicationApplyingSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SchoolCapacityYear1",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                newName: "ProjectedPupilNumbersYear1");

            migrationBuilder.RenameColumn(
                name: "SchoolCapacityYear2",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                newName: "ProjectedPupilNumbersYear2");

            migrationBuilder.RenameColumn(
                name: "SchoolCapacityYear3",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                newName: "ProjectedPupilNumbersYear3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectedPupilNumbersYear1",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                newName: "SchoolCapacityYear1");

            migrationBuilder.RenameColumn(
                name: "ProjectedPupilNumbersYear2",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                newName: "SchoolCapacityYear2");
            
            migrationBuilder.RenameColumn(
                name: "ProjectedPupilNumbersYear1",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                newName: "SchoolCapacityYear2");
        }
    }
}

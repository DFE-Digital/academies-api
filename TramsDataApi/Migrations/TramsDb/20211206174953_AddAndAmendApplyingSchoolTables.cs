using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddAndAmendApplyingSchoolTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_A2BApplyingSchool",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.DropColumn(
                name: "ApplyingSchoolsId",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.AddColumn<string>(
                name: "ApplyingSchoolId",
                schema: "sdd",
                table: "A2BApplyingSchool",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_A2BApplyingSchool",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "ApplyingSchoolId");

            migrationBuilder.CreateTable(
                name: "A2BSelectOption",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BSelectOption", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplyingSchool_SchoolDeclarationBodyAgree",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolDeclarationBodyAgree");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplyingSchool_SchoolDeclarationTeacherChair",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolDeclarationTeacherChair");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplyingSchool_SchoolLeaseExists",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolLeaseExists");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplyingSchool_SchoolLoanExists",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolLoanExists");

            migrationBuilder.AddForeignKey(
                name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolDeclarationBodyAgree",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolDeclarationBodyAgree",
                principalSchema: "sdd",
                principalTable: "A2BSelectOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolDeclarationTeacherChair",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolDeclarationTeacherChair",
                principalSchema: "sdd",
                principalTable: "A2BSelectOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolLeaseExists",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolLeaseExists",
                principalSchema: "sdd",
                principalTable: "A2BSelectOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolLoanExists",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolLoanExists",
                principalSchema: "sdd",
                principalTable: "A2BSelectOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            
            migrationBuilder.InsertData(
                schema: "sdd",
                table: "A2BSelectOption",
                columns: new[] {"Id", "Name"},
                values: new object[] {907660000, "Yes"});
            
            migrationBuilder.InsertData(
                schema: "sdd",
                table: "A2BSelectOption",
                columns: new[] {"Id", "Name"},
                values: new object[] {907660001, "No"});
            
            migrationBuilder.InsertData(
                schema: "sdd",
                table: "A2BSelectOption",
                columns: new[] {"Id", "Name"},
                values: new object[] {907660002, "Unknown"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolDeclarationBodyAgree",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.DropForeignKey(
                name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolDeclarationTeacherChair",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.DropForeignKey(
                name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolLeaseExists",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.DropForeignKey(
                name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolLoanExists",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.DropTable(
                name: "A2BSelectOption",
                schema: "sdd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_A2BApplyingSchool",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.DropIndex(
                name: "IX_A2BApplyingSchool_SchoolDeclarationBodyAgree",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.DropIndex(
                name: "IX_A2BApplyingSchool_SchoolDeclarationTeacherChair",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.DropIndex(
                name: "IX_A2BApplyingSchool_SchoolLeaseExists",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.DropIndex(
                name: "IX_A2BApplyingSchool_SchoolLoanExists",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.DropColumn(
                name: "ApplyingSchoolId",
                schema: "sdd",
                table: "A2BApplyingSchool");

            migrationBuilder.AddColumn<string>(
                name: "ApplyingSchoolsId",
                schema: "sdd",
                table: "A2BApplyingSchool",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_A2BApplyingSchool",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "ApplyingSchoolsId");
        }
    }
}

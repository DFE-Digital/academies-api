using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class ChangeA2BApplicationStatusIdColumnToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "A2BApplicationStatus",
                schema: "sdd");
            
            migrationBuilder.CreateTable(
                name: "A2BApplicationStatus",
                schema: "sdd",
                columns: table => new
                {
                    ApplicationStatusId = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationStatus", x => x.ApplicationStatusId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "A2BApplicationStatus",
                schema: "sdd");
            
            migrationBuilder.CreateTable(
                name: "A2BApplicationStatus",
                schema: "sdd",
                columns: table => new
                {
                    ApplicationStatusId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationStatus", x => x.ApplicationStatusId);
                });
        }
    }
}

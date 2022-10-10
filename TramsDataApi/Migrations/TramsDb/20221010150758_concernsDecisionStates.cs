using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class concernsDecisionStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "sdd",
                table: "ConcernsDecision",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "ConcernsDecisionStates",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsDecisionStates", x => x.Id);
                });

            /*
             *
             * table.ForeignKey(
                    name: "FK_ConcernsDecisionStatus_ConcernsDecisionStates_Id",
                    column: x => x.Id,
                    principalSchema: "sdd",
                    principalTable: "ConcernsDecisionStatus",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
             */
            migrationBuilder.AddForeignKey(
                name: "FK_ConcernsDecisionStatus_ConcernsDecisionStates_Id",
                table: "ConcernsDecision",
                schema: "sdd",
                column: "Status",
                principalTable: "ConcernsDecisionStates",
                principalSchema: "sdd",
                principalColumn: "Id",
                onUpdate: ReferentialAction.NoAction,
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsDecisionStates",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "InProgress" });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsDecisionStates",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Closed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcernsDecisionStatus_ConcernsDecisionStates_Id",
                table: "ConcernsDecision",
                schema:"sdd"
            );

            migrationBuilder.DropTable(
                name: "ConcernsDecisionStates",
                schema: "sdd");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "sdd",
                table: "ConcernsDecision");
        }
    }
}

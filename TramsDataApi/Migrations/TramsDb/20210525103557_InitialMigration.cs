using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sdd");

            migrationBuilder.CreateSequence<int>(
                name: "AcademyTransferProjectUrns",
                startValue: 10000000L,
                minValue: 10000000L);

            migrationBuilder.CreateTable(
                name: "AcademyTransferProjects",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Urn = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR AcademyTransferProjectUrns"),
                    OutgoingTrustUkprn = table.Column<string>(maxLength: 8, nullable: false),
                    WhoInitiatedTheTransfer = table.Column<string>(nullable: true),
                    RddOrEsfaIntervention = table.Column<bool>(nullable: true),
                    RddOrEsfaInterventionDetail = table.Column<string>(nullable: true),
                    TypeOfTransfer = table.Column<string>(nullable: true),
                    OtherTransferTypeDescription = table.Column<string>(nullable: true),
                    TransferFirstDiscussed = table.Column<DateTime>(type: "date", nullable: true),
                    TargetDateForTransfer = table.Column<DateTime>(type: "date", nullable: true),
                    HtbDate = table.Column<DateTime>(type: "date", nullable: true),
                    ProjectRationale = table.Column<string>(nullable: true),
                    TrustSponsorRationale = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    HighProfileShouldBeConsidered = table.Column<bool>(nullable: true),
                    HighProfileFurtherSpecification = table.Column<string>(nullable: true),
                    ComplexLandAndBuildingShouldBeConsidered = table.Column<bool>(nullable: true),
                    ComplexLandAndBuildingFurtherSpecification = table.Column<string>(nullable: true),
                    FinanceAndDebtShouldBeConsidered = table.Column<bool>(nullable: true),
                    FinanceAndDebtFurtherSpecification = table.Column<string>(nullable: true),
                    OtherBenefitValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AcademyT__C5B214360AF6201A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademyTransferProjectIntendedTransferBenefits",
                schema: "sdd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_AcademyTransferProjectId = table.Column<int>(nullable: true),
                    SelectedBenefit = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyTransferProjectIntendedTransferBenefits", x => x.id);
                    table.ForeignKey(
                        name: "FK__AcademyTr__fk_Ac__4316F928",
                        column: x => x.fk_AcademyTransferProjectId,
                        principalSchema: "sdd",
                        principalTable: "AcademyTransferProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferringAcademies",
                schema: "sdd",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_AcademyTransferProjectId = table.Column<int>(nullable: true),
                    OutgoingAcademyUkprn = table.Column<string>(maxLength: 8, nullable: false),
                    IncomingTrustUkprn = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferringAcademies", x => x.id);
                    table.ForeignKey(
                        name: "FK__Transferr__fk_Ac__403A8C7D",
                        column: x => x.fk_AcademyTransferProjectId,
                        principalSchema: "sdd",
                        principalTable: "AcademyTransferProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademyTransferProjectIntendedTransferBenefits_fk_AcademyTransferProjectId",
                schema: "sdd",
                table: "AcademyTransferProjectIntendedTransferBenefits",
                column: "fk_AcademyTransferProjectId");

            migrationBuilder.CreateIndex(
                name: "AcademyTransferProjectUrn",
                schema: "sdd",
                table: "AcademyTransferProjects",
                column: "Urn");

            migrationBuilder.CreateIndex(
                name: "IX_TransferringAcademies_fk_AcademyTransferProjectId",
                schema: "sdd",
                table: "TransferringAcademies",
                column: "fk_AcademyTransferProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademyTransferProjectIntendedTransferBenefits",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "TransferringAcademies",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "AcademyTransferProjects",
                schema: "sdd");

            migrationBuilder.DropSequence(
                name: "AcademyTransferProjectUrns");
        }
    }
}

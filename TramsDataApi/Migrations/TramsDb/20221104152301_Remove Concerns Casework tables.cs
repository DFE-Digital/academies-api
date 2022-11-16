using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class RemoveConcernsCaseworktables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcernsCaseworkTeamMember",
                schema: "sdd");
            
            migrationBuilder.DropTable(
                name: "ConcernsDecisionType",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsDecision",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsDecisionStates",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsDecisionTypeId",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsRecord",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsStatus",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "FinancialPlanCase",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveConditionMapping",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveReasonMapping",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIUnderConsiderationReasonMapping",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterConditionMapping",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterReasonMapping",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "SRMACase",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "SRMAStatus",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsCaseworkTeam",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsMeansOfReferral",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsRating",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsType",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "FinancialPlanStatus",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveCondition",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveCase",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveReason",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIUnderConsiderationCase",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIUnderConsiderationReason",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterCondition",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterCase",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterReason",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "SRMAReason",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsCase",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveConditionType",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NoticeToImproveStatus",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIUnderConsiderationStatus",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterConditionType",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "NTIWarningLetterStatus",
                schema: "sdd");

            migrationBuilder.DropSequence(
                name: "ConcernsGlobalSequence");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "ConcernsGlobalSequence",
                minValue: 1L);

            migrationBuilder.CreateTable(
                name: "ConcernsCase",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseAim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrmEnquiry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeEscalation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeEscalationPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectionOfTravel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextSteps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingUrn = table.Column<int>(type: "int", nullable: false),
                    ReasonAtReview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusUrn = table.Column<int>(type: "int", nullable: false),
                    TrustUkprn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Urn = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CCase__C5B214360AF620234", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsCaseworkTeam",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsCaseworkTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsDecisionStates",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsDecisionStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsDecisionTypeId",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsDecisionTypeId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsMeansOfReferral",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Urn = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CMeansOfReferral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsRating",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Urn = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsStatus",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Urn = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CStatus__C5B214360AF620234", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsType",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Urn = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialPlanStatus",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsClosedStatus = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPlanStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveConditionType",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveConditionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveReason",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveStatus",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsClosingState = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NTIUnderConsiderationReason",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIUnderConsiderationReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NTIUnderConsiderationStatus",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIUnderConsiderationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterConditionType",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterConditionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterReason",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterStatus",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsClosingState = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastTenseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SRMAReason",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Urn = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRMAReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SRMAStatus",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Urn = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRMAStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsDecision",
                schema: "sdd",
                columns: table => new
                {
                    DecisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClosedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ConcernsCaseId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CrmCaseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ReceivedRequestDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RetrospectiveApproval = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubmissionDocumentLink = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    SubmissionRequired = table.Column<bool>(type: "bit", nullable: true),
                    SupportingNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    TotalAmountRequested = table.Column<decimal>(type: "money", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsDecision", x => x.DecisionId);
                    table.ForeignKey(
                        name: "FK_ConcernsDecision_ConcernsCase_ConcernsCaseId",
                        column: x => x.ConcernsCaseId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsCaseworkTeamMember",
                schema: "sdd",
                columns: table => new
                {
                    TeamMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcernsCaseworkTeamId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TeamMember = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsCaseworkTeamMember", x => x.TeamMemberId);
                    table.ForeignKey(
                        name: "FK_ConcernsCaseworkTeamMember_ConcernsCaseworkTeam_ConcernsCaseworkTeamId",
                        column: x => x.ConcernsCaseworkTeamId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsCaseworkTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsRecord",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeansOfReferralId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusUrn = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Urn = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ConcernsGlobalSequence")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ConcernsCase_ConcernsRecord",
                        column: x => x.CaseId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ConcernsRecord_ConcernsMeansOfReferral",
                        column: x => x.MeansOfReferralId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsMeansOfReferral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ConcernsRecord_ConcernsRating",
                        column: x => x.RatingId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ConcernsRecord_ConcernsType",
                        column: x => x.TypeId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialPlanCase",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseUrn = table.Column<int>(type: "int", nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePlanRequested = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateViablePlanReceived = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPlanCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialPlanCase_FinancialPlanStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "sdd",
                        principalTable: "FinancialPlanStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveCondition",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveCondition_NoticeToImproveConditionType_ConditionTypeId",
                        column: x => x.ConditionTypeId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveCase",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseUrn = table.Column<int>(type: "int", nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedStatusId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNTIClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateNTILifted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    SumissionDecisionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveCase_NoticeToImproveStatus_ClosedStatusId",
                        column: x => x.ClosedStatusId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveCase_NoticeToImproveStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NTIUnderConsiderationCase",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseUrn = table.Column<int>(type: "int", nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedStatusId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIUnderConsiderationCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIUnderConsiderationCase_NTIUnderConsiderationStatus_ClosedStatusId",
                        column: x => x.ClosedStatusId,
                        principalSchema: "sdd",
                        principalTable: "NTIUnderConsiderationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterCondition",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterCondition_NTIWarningLetterConditionType_ConditionTypeId",
                        column: x => x.ConditionTypeId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterCase",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseUrn = table.Column<int>(type: "int", nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedStatusId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLetterSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterCase_NTIWarningLetterStatus_ClosedStatusId",
                        column: x => x.ClosedStatusId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterCase_NTIWarningLetterStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SRMACase",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseUrn = table.Column<int>(type: "int", nullable: false),
                    CloseStatusId = table.Column<int>(type: "int", nullable: true),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAccepted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOffered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateReportSentToTrust = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateOfVisit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReasonId = table.Column<int>(type: "int", nullable: true),
                    StartDateOfVisit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Urn = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRMACase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SRMACase_SRMAReason_ReasonId",
                        column: x => x.ReasonId,
                        principalSchema: "sdd",
                        principalTable: "SRMAReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsDecisionType",
                schema: "sdd",
                columns: table => new
                {
                    DecisionId = table.Column<int>(type: "int", nullable: false),
                    DecisionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsDecisionType", x => new { x.DecisionId, x.DecisionTypeId });
                    table.ForeignKey(
                        name: "FK_ConcernsDecisionType_ConcernsDecision_DecisionId",
                        column: x => x.DecisionId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsDecision",
                        principalColumn: "DecisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveConditionMapping",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticeToImproveConditionId = table.Column<int>(type: "int", nullable: false),
                    NoticeToImproveId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveConditionMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveConditionMapping_NoticeToImproveCondition_NoticeToImproveConditionId",
                        column: x => x.NoticeToImproveConditionId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveConditionMapping_NoticeToImproveCase_NoticeToImproveId",
                        column: x => x.NoticeToImproveId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToImproveReasonMapping",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticeToImproveId = table.Column<long>(type: "bigint", nullable: false),
                    NoticeToImproveReasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToImproveReasonMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveReasonMapping_NoticeToImproveCase_NoticeToImproveId",
                        column: x => x.NoticeToImproveId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoticeToImproveReasonMapping_NoticeToImproveReason_NoticeToImproveReasonId",
                        column: x => x.NoticeToImproveReasonId,
                        principalSchema: "sdd",
                        principalTable: "NoticeToImproveReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NTIUnderConsiderationReasonMapping",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NTIUnderConsiderationId = table.Column<long>(type: "bigint", nullable: false),
                    NTIUnderConsiderationReasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIUnderConsiderationReasonMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIUnderConsiderationReasonMapping_NTIUnderConsiderationCase_NTIUnderConsiderationId",
                        column: x => x.NTIUnderConsiderationId,
                        principalSchema: "sdd",
                        principalTable: "NTIUnderConsiderationCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NTIUnderConsiderationReasonMapping_NTIUnderConsiderationReason_NTIUnderConsiderationReasonId",
                        column: x => x.NTIUnderConsiderationReasonId,
                        principalSchema: "sdd",
                        principalTable: "NTIUnderConsiderationReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterConditionMapping",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NTIWarningLetterConditionId = table.Column<int>(type: "int", nullable: false),
                    NTIWarningLetterId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterConditionMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterConditionMapping_NTIWarningLetterCondition_NTIWarningLetterConditionId",
                        column: x => x.NTIWarningLetterConditionId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterConditionMapping_NTIWarningLetterCase_NTIWarningLetterId",
                        column: x => x.NTIWarningLetterId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NTIWarningLetterReasonMapping",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NTIWarningLetterId = table.Column<long>(type: "bigint", nullable: false),
                    NTIWarningLetterReasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTIWarningLetterReasonMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterReasonMapping_NTIWarningLetterCase_NTIWarningLetterId",
                        column: x => x.NTIWarningLetterId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NTIWarningLetterReasonMapping_NTIWarningLetterReason_NTIWarningLetterReasonId",
                        column: x => x.NTIWarningLetterReasonId,
                        principalSchema: "sdd",
                        principalTable: "NTIWarningLetterReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsDecisionStates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "InProgress" },
                    { 2, "Closed" }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsDecisionTypeId",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "NoticeToImprove" },
                    { 2, "Section128" },
                    { 3, "QualifiedFloatingCharge" },
                    { 4, "NonRepayableFinancialSupport" },
                    { 5, "RepayableFinancialSupport" },
                    { 6, "ShortTermCashAdvance" },
                    { 7, "WriteOffRecoverableFunding" },
                    { 8, "OtherFinancialSupport" },
                    { 9, "EstimatesFundingOrPupilNumberAdjustment" },
                    { 10, "EsfaApproval" },
                    { 11, "FreedomOfInformationExemptions" }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsMeansOfReferral",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CIU casework, whistleblowing, self reported, RSCs or other government bodies", "External", new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ESFA activity, TFFT or other departmental activity", "Internal", new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsRating",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red-Plus", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red-Amber", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amber-Green", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "n/a", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsStatus",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Live", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monitoring", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Close", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "ConcernsType",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 9, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Closure", "Governance", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Related party transactions - in year", "Irregularity", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allegations and self reported concerns", "Irregularity", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Safeguarding", "Governance", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Executive Pay", "Governance", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Governance", "Governance", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deficit", "Financial", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clawback", "Financial", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash flow shortfall", "Financial", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Projected deficit / Low future surplus", "Financial", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Financial returns", "Compliance", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Financial reporting", "Compliance", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Force majeure", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "FinancialPlanStatus",
                columns: new[] { "Id", "CreatedAt", "Description", "IsClosedStatus", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awaiting Plan", false, "AwaitingPlan", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Return To Trust", false, "ReturnToTrust", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viable Plan Received", true, "ViablePlanReceived", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abandoned", true, "Abandoned", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIUnderConsiderationReason",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 8, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Safeguarding", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Risk of insolvency", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-Compliance with financial returns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-Compliance with Academies Financial/Trust Handbook", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash flow problems", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cumulative deficit (projected)", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cumulative deficit (actual)", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Governance concerns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIUnderConsiderationStatus",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No further action being taken", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warning letter or NTI can be set up using \"Add to case\".", "To be escalated", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterConditionType",
                columns: new[] { "Id", "CreatedAt", "DisplayOrder", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Standard conditions (mandatory)", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Compliance conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Financial management conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Governance conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash flow problems", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cumulative deficit (actual)", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cumulative deficit (projected)", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Governance concerns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-compliance with Academies Financial/Trust Handbook", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-compliance with financial returns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Risk of insolvency", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Safeguarding", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                columns: new[] { "Id", "CreatedAt", "Description", "IsClosingState", "Name", "PastTenseName", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "You are satisfied that all the conditions have been, or will be, met as outlined in the letter", true, "Conditions met", "Conditions met", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conditions have not been met. Close NTI: Warning letter and begin NTI on case page using \"Add to case\".", true, "Escalate to Notice To Improve", "Escalated to Notice To Improve", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Sent to trust", "", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Preparing warning letter", "", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The warning letter is no longer needed.", true, "Cancel warning letter", "Cancelled", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NoticeToImproveConditionType",
                columns: new[] { "Id", "CreatedAt", "DisplayOrder", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 7, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Additional Financial Support conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Financial management conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Governance conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Compliance conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Safeguarding conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Fraud and irregularity", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Standard conditions", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NoticeToImproveReason",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Risk of insolvency", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cumulative deficit (projected)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Safeguarding", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-compliance with financial returns", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash flow problems", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Governance concerns", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cumulative deficit (actual)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-compliance with Academies Financial/Trust Handbook", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NoticeToImproveStatus",
                columns: new[] { "Id", "CreatedAt", "IsClosingState", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 10, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cancelled", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Closed", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Lifted", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Submission to close NTI in progress", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Submission to lift NTI in progress", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Evidence of NTI non-compliance", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Progress on track", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Issued NTI", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Preparing NTI", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Serious NTI breaches - considering escalation to TWN", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "SRMAReason",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "Urn" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "OfferLinked", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "SchoolsFinancialSupportAndOversight", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "RegionsGroupIntervention", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "SRMAStatus",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "Urn" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Declined", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deployed", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canceled", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "TrustConsidering", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "PreparingForDeployment", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                columns: new[] { "Id", "ConditionTypeId", "CreatedAt", "DisplayOrder", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Trust financial plan", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Action plan", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Lines of accountability", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Providing sufficient challenge", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Scheme of delegation", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Publishing requirements (compliance with)", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 4, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Financial returns", new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "NoticeToImproveCondition",
                columns: new[] { "Id", "ConditionTypeId", "CreatedAt", "DisplayOrder", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 22, 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Excessive executive payments (high pay)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Publishing requirements (compliance with)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Related party Transactions (RPTs)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Review and update safeguarding policies", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Commission external review of safeguarding", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Appoint trustee with leadership responsibility for safeguarding", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 4, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Safeguarding recruitment process", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Novel, contentious, and/or repercussive transactions", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Register of interests", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Procurement policy", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 3, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Admissions", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 6, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Financial returns", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 6, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Delegated freedoms", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 6, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Trustee contact details", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Review of board and executive team capability", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Academy transfer (lower risk)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 5, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Off-payroll payments", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Strengthen governance", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Lines of accountability", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Scheme of delegation", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Audit and risk committee", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Internal audit findings", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Trust financial plan", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Financial management and governance review", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Financial systems & controls and internal scrutiny", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Integrated curriculum and financial planning", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Monthly management accounts", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "National deals for schools", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "School resource management", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Academy ambassadors", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Academy transfer", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Action plan", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "AGM of members", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Board meetings", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Independant review of governance", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Move to latest model funding agreement", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Providing sufficient challenge", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 2, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "School improvement", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 7, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Qualified Floating Charge (QFC)", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsCaseworkTeamMember_ConcernsCaseworkTeamId",
                schema: "sdd",
                table: "ConcernsCaseworkTeamMember",
                column: "ConcernsCaseworkTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsDecision_ConcernsCaseId",
                schema: "sdd",
                table: "ConcernsDecision",
                column: "ConcernsCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsRecord_CaseId",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsRecord_MeansOfReferralId",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "MeansOfReferralId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsRecord_RatingId",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsRecord_TypeId",
                schema: "sdd",
                table: "ConcernsRecord",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialPlanCase_StatusId",
                schema: "sdd",
                table: "FinancialPlanCase",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveCase_ClosedStatusId",
                schema: "sdd",
                table: "NoticeToImproveCase",
                column: "ClosedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveCase_StatusId",
                schema: "sdd",
                table: "NoticeToImproveCase",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveCondition_ConditionTypeId",
                schema: "sdd",
                table: "NoticeToImproveCondition",
                column: "ConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveConditionMapping_NoticeToImproveConditionId",
                schema: "sdd",
                table: "NoticeToImproveConditionMapping",
                column: "NoticeToImproveConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveConditionMapping_NoticeToImproveId",
                schema: "sdd",
                table: "NoticeToImproveConditionMapping",
                column: "NoticeToImproveId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveReasonMapping_NoticeToImproveId",
                schema: "sdd",
                table: "NoticeToImproveReasonMapping",
                column: "NoticeToImproveId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeToImproveReasonMapping_NoticeToImproveReasonId",
                schema: "sdd",
                table: "NoticeToImproveReasonMapping",
                column: "NoticeToImproveReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIUnderConsiderationCase_ClosedStatusId",
                schema: "sdd",
                table: "NTIUnderConsiderationCase",
                column: "ClosedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIUnderConsiderationReasonMapping_NTIUnderConsiderationId",
                schema: "sdd",
                table: "NTIUnderConsiderationReasonMapping",
                column: "NTIUnderConsiderationId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIUnderConsiderationReasonMapping_NTIUnderConsiderationReasonId",
                schema: "sdd",
                table: "NTIUnderConsiderationReasonMapping",
                column: "NTIUnderConsiderationReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterCase_ClosedStatusId",
                schema: "sdd",
                table: "NTIWarningLetterCase",
                column: "ClosedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterCase_StatusId",
                schema: "sdd",
                table: "NTIWarningLetterCase",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterCondition_ConditionTypeId",
                schema: "sdd",
                table: "NTIWarningLetterCondition",
                column: "ConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterConditionMapping_NTIWarningLetterConditionId",
                schema: "sdd",
                table: "NTIWarningLetterConditionMapping",
                column: "NTIWarningLetterConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterConditionMapping_NTIWarningLetterId",
                schema: "sdd",
                table: "NTIWarningLetterConditionMapping",
                column: "NTIWarningLetterId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterReasonMapping_NTIWarningLetterId",
                schema: "sdd",
                table: "NTIWarningLetterReasonMapping",
                column: "NTIWarningLetterId");

            migrationBuilder.CreateIndex(
                name: "IX_NTIWarningLetterReasonMapping_NTIWarningLetterReasonId",
                schema: "sdd",
                table: "NTIWarningLetterReasonMapping",
                column: "NTIWarningLetterReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_SRMACase_ReasonId",
                schema: "sdd",
                table: "SRMACase",
                column: "ReasonId");
        }
    }
}

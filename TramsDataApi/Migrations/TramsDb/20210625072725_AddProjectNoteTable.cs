﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddProjectNoteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    AcademyConversionProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectNotes_AcademyConversionProject_AcademyConversionProjectId",
                        column: x => x.AcademyConversionProjectId,
                        principalSchema: "sdd",
                        principalTable: "AcademyConversionProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNotes_AcademyConversionProjectId",
                table: "ProjectNotes",
                column: "AcademyConversionProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectNotes");
        }
    }
}

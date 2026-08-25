using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ExprienceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RolName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceSkill",
                columns: table => new
                {
                    ExperiencesId = table.Column<int>(type: "integer", nullable: false),
                    SkillsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceSkill", x => new { x.ExperiencesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ExperienceSkill_Experience_ExperiencesId",
                        column: x => x.ExperiencesId,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "CompanyName", "EndDate", "RolName", "StartDate", "WebsiteUrl" },
                values: new object[,]
                {
                    { 1, "iCapps", new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Stagiair", new DateTime(2021, 4, 19, 0, 0, 0, 0, DateTimeKind.Utc), "https://www.icapps.com/" },
                    { 2, "Taglayer", new DateTime(2025, 10, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Fullstack developer", new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Utc), "https://taglayer.com/" }
                });

            migrationBuilder.InsertData(
                table: "ExperienceSkill",
                columns: new[] { "ExperiencesId", "SkillsId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 6 },
                    { 2, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceSkill_SkillsId",
                table: "ExperienceSkill",
                column: "SkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienceSkill");

            migrationBuilder.DropTable(
                name: "Experience");
        }
    }
}

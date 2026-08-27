using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CourseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Institution = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseSkill",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "integer", nullable: false),
                    SkillsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSkill", x => new { x.CoursesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CourseSkill_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Category", "Description", "EndDate", "Institution", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, 0, null, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Karel de Grote", new DateTime(2017, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Toegepaset Informatica, applicatieontwikkeling" },
                    { 2, 1, null, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VDAB", new DateTime(2017, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fullstack developer" }
                });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tags",
                value: "[\"frontend\",\"SPA\"]");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tags",
                value: "[\"fronted\",\"SPA\"]");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Image", "Level", "Name", "Tags" },
                values: new object[,]
                {
                    { 9, "blazor.svg", 1, "Blazor", "[\"frontend\",\"SPA\"]" },
                    { 10, "rest.svg", 3, "REST API", "[\"backend\"]" },
                    { 11, "node.svg", 3, "Node", "[\"backend\"]" }
                });

            migrationBuilder.InsertData(
                table: "CourseSkill",
                columns: new[] { "CoursesId", "SkillsId" },
                values: new object[,]
                {
                    { 2, 5 },
                    { 2, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSkill_SkillsId",
                table: "CourseSkill",
                column: "SkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSkill");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tags",
                value: "[\"frontend\"]");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tags",
                value: "[\"fronted\"]");
        }
    }
}

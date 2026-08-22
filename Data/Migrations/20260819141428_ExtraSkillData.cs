using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtraSkillData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Skills",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Skills",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Image", "Tags" },
                values: new object[] { "vue.svg", "[\"frontend\"]" });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "Tags" },
                values: new object[] { "react.svg", "[\"fronted\"]" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Image", "Level", "Name", "Tags" },
                values: new object[,]
                {
                    { 3, "typescript.svg", 3, "TypeScript", "[\"fullstack\",\"api\"]" },
                    { 4, "tailwind.svg", 2, "Tailwind", "[\"fronted\"]" },
                    { 5, "dotnet.svg", 1, ".NET", "[\"fullstack\",\"api\"]" },
                    { 6, "docker.svg", 2, "Docker", "[\"backend\"]" },
                    { 7, "mongodb.svg", 3, "MongoDB", "[\"backend\",\"database\"]" },
                    { 8, "postgresql.svg", 2, "PostgreSQL", "[\"backend\",\"database\"]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Skills");
        }
    }
}

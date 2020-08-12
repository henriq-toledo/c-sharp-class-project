using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharpClassProject.EfCore.Migrations
{
    public partial class Add_UX_TesterSkills_TesterId_Skill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TesterSkills_TesterId",
                table: "TesterSkills");

            migrationBuilder.CreateIndex(
                name: "UX_TesterSkills_TesterId_Skill",
                table: "TesterSkills",
                columns: new[] { "TesterId", "Skill" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_TesterSkills_TesterId_Skill",
                table: "TesterSkills");

            migrationBuilder.CreateIndex(
                name: "IX_TesterSkills_TesterId",
                table: "TesterSkills",
                column: "TesterId");
        }
    }
}

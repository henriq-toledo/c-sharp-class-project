using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharpClassProject.EfCore.Migrations
{
    public partial class Add_UX_DeveloperSkills_DeveloperId_Skill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DeveloperSkills_DeveloperId",
                table: "DeveloperSkills");

            migrationBuilder.CreateIndex(
                name: "UX_DeveloperSkills_DeveloperId_Skill",
                table: "DeveloperSkills",
                columns: new[] { "DeveloperId", "Skill" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_DeveloperSkills_DeveloperId_Skill",
                table: "DeveloperSkills");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperSkills_DeveloperId",
                table: "DeveloperSkills",
                column: "DeveloperId");
        }
    }
}

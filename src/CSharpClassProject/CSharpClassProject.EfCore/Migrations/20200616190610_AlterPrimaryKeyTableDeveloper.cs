using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharpClassProject.EfCore.Migrations
{
    public partial class AlterPrimaryKeyTableDeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Developers",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "Developers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Developers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Developers",
                table: "Developers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Developers",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Developers");

            migrationBuilder.AddColumn<int>(
                name: "RegisterId",
                table: "Developers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Developers",
                table: "Developers",
                column: "RegisterId");
        }
    }
}

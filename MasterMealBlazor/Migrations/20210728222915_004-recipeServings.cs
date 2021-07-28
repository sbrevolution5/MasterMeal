using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterMealBlazor.Migrations
{
    public partial class _004recipeServings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Servings",
                table: "Recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Servings",
                table: "Recipe");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterMealBlazor.Migrations
{
    public partial class _008chefScreenNameAndRecipeSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipeSource",
                table: "Recipe",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipeSourceUrl",
                table: "Recipe",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScreenName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ShowFullName",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeSource",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "RecipeSourceUrl",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "ScreenName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShowFullName",
                table: "AspNetUsers");
        }
    }
}

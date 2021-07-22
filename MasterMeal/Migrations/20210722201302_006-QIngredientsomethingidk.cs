using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterMeal.Migrations
{
    public partial class _006QIngredientsomethingidk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsesWeight",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfUnits",
                table: "QIngredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfUnits",
                table: "QIngredient");

            migrationBuilder.AddColumn<bool>(
                name: "UsesWeight",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}

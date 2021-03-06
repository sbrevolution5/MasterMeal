using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterMeal.Migrations
{
    public partial class _004parentRecipeQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QIngredient_Recipe_RecipeId",
                table: "QIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "QIngredient",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QIngredient_Recipe_RecipeId",
                table: "QIngredient",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QIngredient_Recipe_RecipeId",
                table: "QIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "QIngredient",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_QIngredient_Recipe_RecipeId",
                table: "QIngredient",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

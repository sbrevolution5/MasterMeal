using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MasterMeal.Migrations
{
    public partial class _002ingredienttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IngredientType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_TypeId",
                table: "Ingredient",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_IngredientType_TypeId",
                table: "Ingredient",
                column: "TypeId",
                principalTable: "IngredientType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientType_TypeId",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "IngredientType");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_TypeId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Ingredient");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Ingredient",
                type: "text",
                nullable: true);
        }
    }
}

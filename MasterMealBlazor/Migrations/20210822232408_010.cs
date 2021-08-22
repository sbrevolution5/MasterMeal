using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterMealBlazor.Migrations
{
    public partial class _010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supply_Recipe_RecipeId",
                table: "Supply");

            migrationBuilder.DropIndex(
                name: "IX_Supply_RecipeId",
                table: "Supply");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Supply");

            migrationBuilder.CreateTable(
                name: "RecipeSupply",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "integer", nullable: false),
                    SuppliesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSupply", x => new { x.RecipesId, x.SuppliesId });
                    table.ForeignKey(
                        name: "FK_RecipeSupply_Recipe_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeSupply_Supply_SuppliesId",
                        column: x => x.SuppliesId,
                        principalTable: "Supply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSupply_SuppliesId",
                table: "RecipeSupply",
                column: "SuppliesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeSupply");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Supply",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supply_RecipeId",
                table: "Supply",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supply_Recipe_RecipeId",
                table: "Supply",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

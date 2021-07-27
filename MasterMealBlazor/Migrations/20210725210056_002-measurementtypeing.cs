using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterMealBlazor.Migrations
{
    public partial class _002measurementtypeing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "measurementType",
                table: "Ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "measurementType",
                table: "Ingredient");
        }
    }
}
